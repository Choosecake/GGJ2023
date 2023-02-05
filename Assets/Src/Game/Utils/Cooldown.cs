using System.Collections.Generic;
using UnityEngine;

namespace Game.Src.Game.Utils
{
    public class Cooldown
    {
        private Dictionary<GameObject, float> _lastActions = new();

        public float cooldownSeconds;

        public Cooldown(float cooldownSeconds)
        {
            this.cooldownSeconds = cooldownSeconds;
        }


        public bool Execute(GameObject go)
        {
            var lastAction = _lastActions.ContainsKey(go) ? _lastActions[go] : 0;
            var now = Time.time;
            var elapsed = now - lastAction;
            if (elapsed >= cooldownSeconds)
            {
                _lastActions[go] = now;
                return true;
            }

            return false;
        }
    }
}