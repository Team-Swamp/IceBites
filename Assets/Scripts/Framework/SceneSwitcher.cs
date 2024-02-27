using UnityEngine;
using UnityEngine.SceneManagement;

namespace FrameWork
{
    public sealed class SceneSwitcher : MonoBehaviour
    {
        [SerializeField] private bool loadSceneInAwake;
        [SerializeField] private string sceneToLoad;

        private void Awake()
        {
            if (loadSceneInAwake)
                LoadScene();
        }

        /// <summary>
        /// Load the scene that is set (sceneToLoad property).
        /// </summary>
        public void LoadScene() => SceneManager.LoadScene(sceneToLoad);

        /// <summary>
        /// Set the sceneToLoad property to a new scene, if this succeeds it will load it, otherwise it will give an error.
        /// </summary>
        /// <param name="targetScene">The target scene to load.</param>
        public void SetAndLoadScene(string targetScene)
        {
            if(SetSceneToLoad(targetScene))
                LoadScene();
        }

        /// <summary>
        /// Set the sceneToLoad property to a new scene, if it's not in the build settings you will get an error.
        /// </summary>
        /// <param name="targetScene">The target scene to set as sceneToLoad.</param>
        /// <returns>When succeeding the scene is set. Otherwise not with an error.</returns>>
        public bool SetSceneToLoad(string targetScene)
        {
            if (SceneExists(targetScene))
            {
                sceneToLoad = targetScene;
                return true;
            }
            
            Debug.LogError($"Scene '{targetScene}' does not exist in the project.");
            return false;
        }

        private bool SceneExists(string sceneName)
        {
            int sceneCount = SceneManager.sceneCountInBuildSettings;

            for (int i = 0; i < sceneCount; i++)
            {
                string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
                string sceneNameInBuildSettings = System.IO.Path.GetFileNameWithoutExtension(scenePath);

                if (sceneNameInBuildSettings == sceneName)
                    return true;
            }

            return false;
        }
    }
}
