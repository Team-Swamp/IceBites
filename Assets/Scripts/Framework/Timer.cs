using FrameWork.Structs;
using UnityEngine;
using UnityEngine.Events;

namespace FrameWork
{
    public sealed class Timer : MonoBehaviour
    {
        [SerializeField] private bool isCountingUp;
        [SerializeField] private bool canCount;
        [SerializeField] private float startingTime;
        [SerializeField] private float timerThreshold;

        private float _currentTimer;
        private bool _isTimerLenghtSmall;
        private TimerData _timerData;

        #region Events
        
        [SerializeField] private UnityEvent onTimerDone = new();
        [SerializeField] private UnityEvent onTimerPassedThreshold = new();
        [SerializeField] private UnityEvent onReset = new();

        #endregion

        private void Awake()
        {
            _timerData = new TimerData(180, 15);

            if (startingTime == 0)
                startingTime = _timerData.mainTimerLenght;
        }

        private void Update() => Counting();

        /// <summary>
        /// Reset the timer to startingTime and calls the onReset event.
        /// </summary>
        public void ResetTimer()
        {
            onReset?.Invoke();
            _currentTimer = startingTime;
        }

        /// <summary>
        /// Set the timer lenght, when resetting it will use this number.
        /// </summary>
        /// <param name="target">The target amount for the timer</param>
        public void SetTimerLenght(float target) => _currentTimer = target;

        /// <summary>
        /// Toggles the current timer to the big lenght if previously was small, otherwise in reverse.
        /// </summary>
        public void ToggleTimerLengthPreference()
        {
            _currentTimer = _isTimerLenghtSmall
                ? _timerData.mainTimerLenght
                : _timerData.smallTimerLenght;

            print($"Current timer lenght is now: {_currentTimer}.");
            
            _isTimerLenghtSmall = !_isTimerLenghtSmall;
        }

        /// <summary>
        /// Get the timer it's current lenght.
        /// </summary>
        /// <returns>The current timer lenght</returns>
        public float GetCurrentTimerLenght() => _currentTimer;
        
        private void Counting()
        {
            if(!canCount)
                return;

            _currentTimer = isCountingUp 
                ? _currentTimer + Time.deltaTime 
                : _currentTimer - Time.deltaTime;
            
            switch (isCountingUp)
            {
                case false 
                when _currentTimer <= 0:
                    onTimerDone?.Invoke();
                    break;
                case true 
                when _currentTimer > timerThreshold:
                    onTimerPassedThreshold?.Invoke();
                    break;
            }
        }
    }
}