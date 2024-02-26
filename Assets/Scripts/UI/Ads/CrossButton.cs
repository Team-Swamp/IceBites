using System;
using FrameWork;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Ads
{
    /// <summary>
    /// This class is not in use.
    /// </summary>
    public sealed class CrossButton : MonoBehaviour
    {
        [SerializeField] private Image cross;
        [SerializeField] private Button button;
        [SerializeField] private Timer timer;

        private bool _canLoad;

        private void Start() => InitCrossButton();

        private void Update() => UpdateLoading();

        /// <summary>
        /// Set the load property and timer can count, if false then the button will disable.
        /// </summary>
        /// <param name="target">The value to set it to</param>
        public void SetLoad(bool target)
        {
            _canLoad = target;
            timer.SetCanCount(_canLoad);
            
            if(!_canLoad)
                button.enabled = false;
        }

        private void InitCrossButton()
        {
            if (!cross)
                cross = GetComponent<Image>();

            if (!button)
                button = GetComponent<Button>();
            
            button.enabled = false;
            SetLoad(false);
        }
        
        private void UpdateLoading()
        {
            if(!_canLoad)
                return;
            
            cross.fillAmount = 1 - timer.GetCurrentTimerPercentage();

            if (!(Math.Abs(cross.fillAmount - 1) < 0.01f)) 
                return;
            
            button.enabled = true;
            timer.SetCanCount(false);
        }
    }
}
