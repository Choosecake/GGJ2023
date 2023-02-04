using System;
using System.Collections;
using UnityEngine;

namespace Game
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotationTime = 1f;
        [SerializeField] private Transform _cameraHolder;


        private Vector3 cameraOffset;

        public Vector2 MoveInput
        {
            get => _moveInput;
            set => _moveInput = value;
        }

        private Rigidbody _rigidbody;
        private Vector2 _moveInput;
        private Vector3 _moveDirection;
        private float _rotationVelocity;
        private float _rotationAngle;
        private float movementAngle;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            cameraOffset = _cameraHolder.position - transform.position;
        }

        private void Update()
        {
            DefineMovementAngle(out movementAngle, ref _moveDirection);

            if (_moveInput == Vector2.zero)
            {
                return;
            }

            LerpRotate(movementAngle);
        }

        private void FixedUpdate()
        {
            if (IsMoving())
            {
                _rigidbody.velocity = _moveDirection * _moveSpeed;
            }

            _cameraHolder.position = transform.position + cameraOffset;
        }

        private void LerpRotate(float movementAngle)
        {
            _rotationAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, movementAngle, ref _rotationVelocity,
                _rotationTime / 100);
            transform.rotation = Quaternion.Euler(0f, _rotationAngle, 0f);
        }

        private void DefineMovementAngle(out float movementAngle, ref Vector3 moveDirection)
        {
            movementAngle = Mathf.Atan2(_moveInput.x, _moveInput.y) * Mathf.Rad2Deg + _cameraHolder.eulerAngles.y;

            moveDirection = Quaternion.Euler(0f, movementAngle, 0f) * Vector3.forward;
            moveDirection.Normalize();
        }

        public bool IsMoving()
        {
            if (_moveInput == Vector2.zero)
            {
                return false;
            }

            return true;
        }
    }
}