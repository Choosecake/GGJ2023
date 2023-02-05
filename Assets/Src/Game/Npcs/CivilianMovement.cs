using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Game.Src.Game.Npcs
{
    public class CivilianMovement : NpcMovement
    {
        [SerializeField] private Transform[] _beacons;
        [SerializeField] private Transform _player;
        [SerializeField] private float _scareDistance;
        [SerializeField] private float _minimumBeaconDistance;
        private Transform _selectedBeacon;
        [SerializeField] private bool _isInBeacon = false;
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
                if (!_isInBeacon)
                {
                    DefineBeacon();
                } 
                
                _goal = _selectedBeacon;
            }
        }

        private int DefineBeacon()
        {
            int index;
            _selectedBeacon = _beacons[0];
            for (index = 0; index < _beacons.Length - 1; index++)
            {
                if (Vector3.Distance
                        (transform.position, _beacons[index].transform.position)
                    < Vector3.Distance
                        (transform.position, _selectedBeacon.transform.position)
                   )
                {
                    _selectedBeacon = _beacons[index];
                }
            }

            return index; 
        }
    }
}