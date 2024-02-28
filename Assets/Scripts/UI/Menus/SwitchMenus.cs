using UnityEngine;
using UnityEngine.Events;

namespace UI.Menus
{
    public sealed class SwitchMenus : MonoBehaviour
    {
        private bool _isPaused;
        
        [SerializeField] private UnityEvent pausingGame = new();
        
        /// <summary>
        /// This hides a certain gameobject.
        /// </summary>
        /// <param name="hidden">This will be the gameobject that gets hidden</param>
        public void HideMenu(GameObject hidden) => hidden.SetActive(false);
        
        /// <summary>
        /// This will reveal a certain gameobject.
        /// </summary>
        /// <param name="active">This is the object that gets revealed</param>
        public void ActivateMenu(GameObject active) => active.SetActive(true);

        /// <summary>
        /// This will either stop or resume the time in game allowing for a correct pause.
        /// </summary>
        public void PauseGame()
        {
            _isPaused = !_isPaused;
            Time.timeScale = _isPaused ? 0f : 1f;
        }
        
        /// <summary>
        /// This checks if the game is already paused, if not it will pause.
        /// </summary>
        public void PausingEvent()
        {
            if(!_isPaused) 
                pausingGame?.Invoke();
        }
    }
}
