using System;
using Game.Src.Game.Services;
using Game.Src.Game.System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

namespace Game.Src.Game
{
    public class Main : MonoBehaviour
    {
        public AudioMixer Mixer;


        public event Action nextFrame;

        private void Start()
        {
            DontDestroyOnLoad(this);
            RegisterGlobals();
            Global.Services().State.OnStateChange += OnStateChange;

            // Start the menu transition
            Global.Services().State.Transition(States.Menu);
        }

        private void OnStateChange(States before, States after)
        {
            if (after == States.Menu && before == States.Boot)
            {
                Global.Services().UI.OpenScreen(Screens.MainMenu);
                return;
            }


            if (after == States.Game)
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(Scenes.Game);
                nextFrame += () => { Global.Services().UI.OpenScreen(Screens.HUD); };
                return;
            }

            if (after == States.Lost)
            {
                Time.timeScale = 0;
                nextFrame += () => { Global.Services().UI.OpenScreen(Screens.EndGame); };
            }

            if (after == States.Menu && before == States.Lost)
            {
                SceneManager.LoadScene(Scenes.Menu);
                nextFrame += () => { Global.Services().UI.OpenScreen(Screens.MainMenu); };

            }
        }

        private void RegisterGlobals()
        {
            var services = CreateServices();
            Global.Register(services);
            var systems = CreateSystems();
            Global.Register(systems);
            Global.Register(Mixer);
        }

        private Systems CreateSystems()
        {
            return new Systems() { Damage = new DamageSystem() };
        }

        private void Update()
        {
            if (nextFrame == null) return;
            nextFrame.Invoke();
            foreach (var d in nextFrame.GetInvocationList())
            {
                nextFrame -= (Action)d;
            }
        }

        public GameServices CreateServices()
        {
            return new GameServices() { Audio = new AudioService(), UI = new UIService(), State = new GameState() };
        }
    }
}