using System;
using System.Collections;
using System.Collections.Generic;
using Game.Src.Game;
using Game.Src.Game.Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Game.Presenters
{
    public class MenuPresenter : MonoBehaviour
    {
        private UIDocument m_UIDocument;


        private Button startButton;
        private Button optionsButton;
        private Button quitButton;


        private void LoadReferences()
        {
            m_UIDocument = GetComponent<UIDocument>();
            var rootElement = m_UIDocument.rootVisualElement;
            startButton = rootElement.Q<Button>("playButton");
            optionsButton = rootElement.Q<Button>("optionsButton");
            quitButton = rootElement.Q<Button>("quitButton");
        }

        void Start()
        {
            LoadReferences();
            startButton.clicked += OnStartClicked;
            optionsButton.clicked += OnOptionsClicked;
            quitButton.clicked += OnQuitClicked;
        }

        private void OnQuitClicked()
        {
            Application.Quit();
        }

        private void OnOptionsClicked()
        {
            Global.Services()
                .UI.OpenScreen(Screens.Options);
        }

        private void OnStartClicked()
        {
            Debug.Log("Clicked start!");
            startButton.SetEnabled(false);
            SceneManager.LoadScene(Scenes.Game);
        }


        // Update is called once per frame
    }
}