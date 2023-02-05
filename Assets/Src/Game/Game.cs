using System;
using Game.Src.Game.Services;
using UnityEngine;
using UnityEngine.Audio;

namespace Game.Src.Game
{
    public class Game : MonoBehaviour
    {
        public AudioMixer Mixer;

        public static AudioMixer mixer;


        private void Start()
        {
            mixer = Mixer;
            DontDestroyOnLoad(this);
            Load();
        }

        private void Load()
        {
            var services = CreateServices();
            Global.Register(services);
            services.Audio.Init();
            services.State.Transition(States.Menu);
            services.UI.OpenScreen(Screens.MainMenu);
        }


        public GameServices CreateServices()
        {
            return new GameServices() { Audio = new AudioService(), UI = new UIService(), State = new GameState() };
        }
    }
}