using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerManager : MonoBehaviour
    {
        private PlayerMovement _movement;
        private PlayerInputManager _input;

        
        void Awake()
        {
            _input = GetComponent<PlayerInputManager>();
            _movement = GetComponent<PlayerMovement>();
        }
        
        void Update()
        {
            _movement.MoveInput = _input.InputActions.Movement.MoveInput.ReadValue<Vector2>();
        }
    }
}