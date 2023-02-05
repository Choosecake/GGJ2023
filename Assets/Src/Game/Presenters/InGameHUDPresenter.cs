using System;
using System.Collections;
using System.Collections.Generic;
using Game.Src.Game;
using Game.Src.Game.Components;
using Game.Src.Game.Services;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UIElements.Button;
using Slider = UnityEngine.UIElements.Slider;

namespace Game.Presenters
{
    public class InGameHUDPresenter : MonoBehaviour
    {
        private UIDocument m_UIDocument;
        private Label healthCheck;
        private Damageable player;

        private void LoadReferences()
        {
            m_UIDocument = GetComponent<UIDocument>();
            var rootElement = m_UIDocument.rootVisualElement;
            healthCheck = rootElement.Q<Label>("health");
            player = GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<Damageable>();
        }

        void Start()
        {
            LoadReferences();
        }


        // Update is called once per frame
        private void Update()
        {
            healthCheck.text = $"{player.CurrentHealth}/{player.InitialHealth}";
        }
    }
}