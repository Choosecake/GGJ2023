using System;
using Game;
using Game.Movement;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerManager : MonoBehaviour
    {
        private PlayerMovement _movement;
        private Grabber _grabber;
        private PlayerInputManager _input;

        
        void Awake()
        {
            _input = GetComponent<PlayerInputManager>();
            _movement = GetComponent<PlayerMovement>();
            _grabber = GetComponent<Grabber>();
        }
        
        void Update()
        {
            _grabber.GrabActivated = _input.InputActions.Gameplay.Grab.WasPressedThisFrame();
            _movement.MoveInput = _input.InputActions.Gameplay.MoveInput.ReadValue<Vector2>();
            
        }
    }
}