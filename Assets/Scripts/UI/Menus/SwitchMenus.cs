using FrameWork;
using UnityEngine;
using UnityEngine.Events;

namespace UI.Menus
{
    public sealed class SwitchMenus : MonoBehaviour
    {
        private bool _isPaused;
        
        [SerializeField] private UnityEvent pausingGame = new();
        
        /// <summary>
        /// This hides a certain game object.
        /// </summary>
        /// <param name="hidden">This will be the game object that gets hidden</param>
        public void HideMenu(GameObject hidden) => hidden.SetActive(false);
        
        /// <summary>
        /// This will reveal a certain game object.
        /// </summary>
        /// <param name="active">This is the object that gets revealed</param>
        public void ActivateMenu(GameObject active) => active.SetActive(true);

        /// <summary>
        /// This will either stop or resume the time in game allowing for a correct pause.
        /// </summary>
        public void TogglePauseGame()
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

        /// <summary>
        /// Set the sceneToLoad property to a new scene, if this succeeds it will load it, otherwise it will give an error.
        /// </summary>
        /// <param name="targetScene">The target scene to load.</param>
        public void SetAndLoadScene(string targetScene) => SceneSwitcher.Instance.SetAndLoadScene(targetScene);
        
        /// <summary>
        /// Set the sceneToLoad property to a new scene, if this succeeds it will load it asynchronously. Otherwise it will give an error.
        /// </summary>
        /// <param name="targetScene">The target scene to load.</param>
        public void SetAndLoadAsyncScene(string targetScene) => SceneSwitcher.Instance.SetAndLoadAsyncScene(targetScene);

        /// <summary>
        /// Quits the application, made for Unity events.
        /// </summary>
        public void Quit() => Application.Quit();
    }
}
