using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;

namespace Game.Src.Game.Npcs
{
    public class CivilianMovement : MonoBehaviour
    {
        [SerializeField] NavMeshAgent _agent;
        [SerializeField] private Transform[] _beacons;
        [SerializeField] private Transform _player;
        [SerializeField] private bool _isInBeacon = false;
        [SerializeField] private float _scareDistance;
        [SerializeField] private float _minimumBeaconDistance;
        private Transform _selectedBeacon;
        private float _rotationVelocity;
        private float _rotationAngle;
        private float movementAngle;
        private int currentBeacon = 0;
        
        private void Update()
        {
            for (int i = 0; i < _beacons.Length - 1; i++)
            {
                if (Vector3.Distance(transform.position, _beacons[i].position) < _minimumBeaconDistance)
                {
                    _isInBeacon = true;
                }
                else
                {
                    _isInBeacon = false;
                }
            }
            
            if (Vector3.Distance(transform.position, _player.position) < _scareDistance)
            {
                DefineBeacon();
                _agent.SetDestination(_selectedBeacon.position);
            }
            
        }

        private void DefineBeacon()
        {
            if (_isInBeacon)
            {
                currentBeacon += 1;
            }
            else
            {
                currentBeacon = 0;
                for (int i = 0; i < _beacons.Length - 1; i++)
                {
                    if (Vector3.Distance(transform.position, _beacons[i].position) 
                        < Vector3.Distance(transform.position, _beacons[currentBeacon].position))
                    {
                        currentBeacon = i;
                    }
                }
            }

            _selectedBeacon = _beacons[currentBeacon];
        }
    }
}