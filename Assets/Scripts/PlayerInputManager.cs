using UnityEngine;

namespace Player
{
    public class PlayerInputManager : MonoBehaviour
    {
        public InputActions InputActions { get; private set; }
        
        void Awake()
        {
            InputActions = new InputActions();
        }
        
        void OnEnable()
        {
            InputActions.Enable();
        }
        
        void OnDisable()
        {
            InputActions.Disable();
        }
    }
}