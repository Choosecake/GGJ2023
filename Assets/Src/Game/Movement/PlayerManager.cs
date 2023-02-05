using System;
using Game;
using Game.Movement;
using Game.Src.Game;
using Game.Src.Game.Components;
using Game.Src.Game.Services;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerManager : MonoBehaviour
    {
        private PlayerMovement _movement;
        private Grabber _grabber;
        private PlayerInputManager _input;
        private Damageable _damageable;

        void Awake()
        {
            _input = GetComponent<PlayerInputManager>();
            _movement = GetComponent<PlayerMovement>();
            _grabber = GetComponent<Grabber>();
            Global.Systems().Damage.DiedEvent += DiedEvent;
        }

        private void DiedEvent(Damageable entity, GameObject attacker)
        {
            if (entity.gameObject.CompareTag(Tags.Player))
            {
                Global.Services().State.Transition(States.Lost);

            }
        }

        void Update()
        {
            _grabber.GrabActivated = _input.InputActions.Gameplay.Grab.WasPressedThisFrame();
            _movement.MoveInput = _input.InputActions.Gameplay.MoveInput.ReadValue<Vector2>();
        }
    }
}