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
    public class EndGamePresenter : MonoBehaviour
    {
        private UIDocument m_UIDocument;
        private Button quit;
        private Button menu;

        private void LoadReferences()
        {
            m_UIDocument = GetComponent<UIDocument>();
            var rootElement = m_UIDocument.rootVisualElement;
            quit = rootElement.Q<Button>("quit");
            menu = rootElement.Q<Button>("menu");
        }

        void Start()
        {
            LoadReferences();
            menu.clicked += OnMenuClicked;
            quit.clicked += OnQuitClicked;
        }

        private void OnMenuClicked()
        {
            Global.Services().State.Transition(States.Menu);
        }

        private void OnQuitClicked()
        {
            Application.Quit();
        }


        // Update is called once per frame
    }
}