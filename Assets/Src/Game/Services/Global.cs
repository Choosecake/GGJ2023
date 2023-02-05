using System;
using System.Collections.Generic;
using Game.Src.Game.System;

namespace Game.Src.Game.Services
{
    public static class Global
    {
        private static Dictionary<Type, object> _values = new();


        public static T Resolve<T>()
        {
            if (_values.TryGetValue(typeof(T), out var dependency))
            {
                return (T)dependency;
            }

            throw new ArgumentException("Dependency not found " + typeof(T).FullName);
        }


        public static void Register<T>(T value)
        {
            _values[typeof(T)] = value;
        }

        public static GameServices Services()
        {
            return Resolve<GameServices>();
        }

        public static Systems Systems()
        {
            return Resolve<Systems>();
        }
    }
}