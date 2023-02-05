using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Src.Game.Npcs
{
    public abstract class NpcMovement : MonoBehaviour
    {
        [HideInInspector] public Transform _goal;
        private NavMeshAgent _agent;
        private float _rotationVelocity;
        private float _rotationAngle;
        private float movementAngle;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            _agent.destination = _goal.position;
        }
    }
}