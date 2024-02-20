using System;
using FrameWork;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Ads
{
    public sealed class CrossButton : MonoBehaviour
    {
        [SerializeField] private Image cross;
        [SerializeField] private Button button;
        [SerializeField] private Timer timer;

        private bool _canLoad;

        private void Awake()
        {
            InitCrossButton();
            SetLoad(true); // temp
        }

        private void Update() => UpdateLoading();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        public void SetLoad(bool target)
        {
            _canLoad = target;
            
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
        }
        
        private void UpdateLoading()
        {
            if(!_canLoad)
                return;
            
            cross.fillAmount = 1 - timer.GetCurrentTimerPercentage();// here an extra timer is needed and the main timer for turning on and off

            // if (Math.Abs(cross.fillAmount - 1) < 0.01f)
                button.enabled = Math.Abs(cross.fillAmount - 1) < 0.01f;
        }
    }
}
