using UnityEngine;

namespace UI
{
    public class SwitchMenus : MonoBehaviour
    {
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
    }
}
