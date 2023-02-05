using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Game
{
    public class ExplosiveObject : MonoBehaviour
    {
        [SerializeField] private float _explosionForce;
        [SerializeField] private bool _activateExplosion = false;
        private Vector3 _direction;
        private List<GameObject> _objectPieces = new List<GameObject>();

        private void Start()
        {
            for (int i = 0; i < transform.childCount - 1; i++)
            {
                _objectPieces.Add(transform.GetChild(i).gameObject);
            }
        }

        private void FixedUpdate()
        {
            if (_activateExplosion)
            {
                GetComponent<BoxCollider>().isTrigger = true;
                
                int currentObject = 0;
                foreach (var objectPiece in _objectPieces)
                {
                    var rigidbody = objectPiece.GetComponent<Rigidbody>();
                    rigidbody.isKinematic = false;
                    
                    objectPiece.GetComponent<MeshCollider>().isTrigger = false;

                    var randomValue = UnityEngine.Random.value;
                    _direction = new Vector3(randomValue * currentObject, randomValue * currentObject,
                        randomValue * currentObject);
                    
                    rigidbody.velocity = _direction * _explosionForce;

                    currentObject += 1;
                }
            }
        }
    }
}
