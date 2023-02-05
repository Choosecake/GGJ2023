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
        private void Update()
        {
            if (Vector3.Distance(transform.position, _player.position) < _scareDistance)
            {
                Transform selectedBeacon = _beacons[0];
                foreach (var beacon in _beacons)
                {
                    if (Vector3.Distance
                            (beacon.transform.position, transform.position) 
                        < Vector3.Distance
                            (selectedBeacon.transform.position, transform.position)
                        )
                    {
                        selectedBeacon = beacon;
                    }
                }

                _goal = selectedBeacon;
            }
        }
    }
}