using System.Collections;
using System.Collections.Generic;
using Game.Src.Game.Components;
using Game.Src.Game.Services;
using Game.Src.Game.Utils;
using UnityEngine;

namespace Game.Components
{
    public class IntervalDamage : MonoBehaviour
    {
        public float CooldownInSeconds;
        public float Damage;


        private InsideCollider _inside;
        private Cooldown _cd;

        void Start()
        {
            _cd = new Cooldown(CooldownInSeconds);
            _inside = GetInsideCollider();
            _inside.Filter = c => c.gameObject.GetComponentInParent<Damageable>() != null;
        }

        private InsideCollider GetInsideCollider()
        {
            var current = GetComponent<InsideCollider>();
            if (current != null)
            {
                return current;
            }

            return gameObject.AddComponent<InsideCollider>();
        }

        // Update is called once per frame
        void Update()
        {
            foreach (var o in GetInsideCollider().Inside)
            {
                var damageable = o.GetComponentInParent<Damageable>();

                if (_cd.Execute(o))
                {
                    Global.Systems().Damage.Damage(gameObject, damageable, Damage);
                }
            }
        }
    }
}