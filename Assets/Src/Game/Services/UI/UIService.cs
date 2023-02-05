using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Game.Src.Game.Services
{
    public class UIService
    {
        private GameObject uiPrefab;

        private Screen _currentScreen = null;

        public UIService()
        {
            uiPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/DocumentUI.prefab");
        }

        public void OpenScreen(Screen scr)
        {
            var tree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(scr.DocumentPath);
            var uiDocument = GetUiDocument(scr.Layer);
            if (_currentScreen != null)
            {
                Object.Destroy(uiDocument.gameObject.GetComponent(_currentScreen.Presenter));
            }

            uiDocument.visualTreeAsset = tree;
            uiDocument.gameObject.AddComponent(scr.Presenter);
        }


        private UIDocument GetUiDocument(int layer)
        {
            var uiDocuments = Object.FindObjectsOfType<UIDocument>();
            var uiDocument = uiDocuments.FirstOrDefault(u => (double)u.sortingOrder == (double)layer);

            if (uiDocument == null)
            {
                uiDocument = CreateUIDocument(layer);
            }

            return uiDocument;
        }

        private UIDocument CreateUIDocument(int layer)
        {
            var go = Object.Instantiate(uiPrefab);
            var ui = go.GetComponent<UIDocument>();
            ui.sortingOrder = layer;
            return ui;
        }
    }
}