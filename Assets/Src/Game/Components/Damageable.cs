using System;
using UnityEngine;

namespace Game.Src.Game.Components
{
    public class Damageable : MonoBehaviour
    {
        public float InitialHealth;
        public float CurrentHealth;

        private void Start()
        {
            CurrentHealth = InitialHealth;
        }
    }
}