using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Game.Src.Game.Services
{
    public enum VolumeType
    {
        Master,
        Effects,
        Music
    }


    public class AudioService
    {
        private static Dictionary<VolumeType, string> _volumeKeys = new() { { VolumeType.Master, "MasterVolume" }, { VolumeType.Effects, "EffectVolume" }, { VolumeType.Music, "MusicVolume" } };


        private static float defaultVolume = 0.7f;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value">0 - 1</param>
        public void SetVolume(VolumeType type, float value)
        {
            var stringKey = _volumeKeys[type];

            Global.Resolve<AudioMixer>().SetFloat(stringKey, NormalizeVolume(value));
            PlayerPrefs.SetFloat(stringKey, value);
        }

        public float GetVolume(VolumeType type)
        {
            var key = _volumeKeys[type];
            if (!PlayerPrefs.HasKey(key))
            {
                return defaultVolume;
            }

            return PlayerPrefs.GetFloat(key);
        }

        public float NormalizeVolume(float volume)
        {
            return Mathf.Lerp(-80, 0, volume);
        }

        public void Init()
        {
            foreach (var (type, key) in _volumeKeys)
            {
                Global.Resolve<AudioMixer>().SetFloat(key, NormalizeVolume(GetVolume(type)));
            }
        }
    }
}