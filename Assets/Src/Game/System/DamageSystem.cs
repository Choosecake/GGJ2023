using Game.Src.Game.Components;
using UnityEngine;

namespace Game.Src.Game.System
{
    public class DamageSystem
    {
        public delegate void DeadEventHandler(Damageable entity, GameObject attacker);

        public delegate void TookDamageEventHandler(Damageable entity, GameObject attacker, float damage);

        public event DeadEventHandler DiedEvent;
        public event TookDamageEventHandler TookDamageEvent;

        public void Damage(GameObject source, Damageable damageable, float damage)
        {
            damageable.CurrentHealth -= damage;
            TookDamageEvent?.Invoke(damageable, source, damage);
            if (damageable.CurrentHealth <= 0)
            {
                DiedEvent?.Invoke(damageable, source);
            }
        }
    }
}