using System;
using System.Collections;
using System.Collections.Generic;
using Game.Src.Game;
using Game.Src.Game.Services;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Game.Presenters
{
    public class OptionsPresenter : MonoBehaviour
    {
        private UIDocument m_UIDocument;
        private Button backButton;
        private AudioMixer mixer;
        private Slider effectsVolume;
        private Slider musicVolume;
        private Slider masterVolume;

        private void LoadReferences()
        {
            m_UIDocument = GetComponent<UIDocument>();
            var rootElement = m_UIDocument.rootVisualElement;
            backButton = rootElement.Q<Button>("backButton");
            effectsVolume = rootElement.Q<Slider>("effectsVolume");
            musicVolume = rootElement.Q<Slider>("musicVolume");
            masterVolume = rootElement.Q<Slider>("generalVolume");
        }

        void Start()
        {
            LoadReferences();
            backButton.clicked += OnBackClicked;
            var audio = Global.Services().Audio;
            masterVolume.value = audio.GetVolume(VolumeType.Master);
            effectsVolume.value = audio.GetVolume(VolumeType.Effects);
            musicVolume.value = audio.GetVolume(VolumeType.Music);
            masterVolume.RegisterValueChangedCallback(evt => { audio.SetVolume(VolumeType.Master, evt.newValue); });
            effectsVolume.RegisterValueChangedCallback(evt => { audio.SetVolume(VolumeType.Effects, evt.newValue); });
            musicVolume.RegisterValueChangedCallback(evt => { audio.SetVolume(VolumeType.Music, evt.newValue); });
        }


        private void OnBackClicked()
        {
            Global.Services()
                .UI.OpenScreen(Screens.MainMenu);
        }


        // Update is called once per frame
    }
}