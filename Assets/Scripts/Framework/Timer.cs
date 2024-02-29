using FrameWork.Structs;
using UnityEngine;
using UnityEngine.Events;

namespace FrameWork
{
    public sealed class Timer : MonoBehaviour
    {
        private const int BIG_TIMER = 180;
        private const int SMALL_TIMER = 15;
        
        [SerializeField] private bool isCountingUp;
        [SerializeField] private bool canCountOnAwake;
        [SerializeField] private bool canCount;
        [SerializeField] private float startingTime;
        [SerializeField] private float timerThreshold;

        private float _currentTimer;
        private bool _isStarting;
        private bool _isTimerLenghtSmall;
        private TimerData _timerData;

        #region Events
        
        [SerializeField] private UnityEvent onTimerDone = new();
        [SerializeField] private UnityEvent onTimerPassedThreshold = new();
        [SerializeField] private UnityEvent onStart = new();
        [SerializeField] private UnityEvent onReset = new();

        #endregion

        private void Awake()
        {
            SetCanCount(canCountOnAwake);
            _timerData = new TimerData(BIG_TIMER, SMALL_TIMER);

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
            _isStarting = true;
        }

        /// <summary>
        /// Set the canCount property, when setting it to true it will start counting, otherwise is stops.
        /// </summary>
        /// <param name="target">The target for the property</param>
        public void SetCanCount(bool target) => canCount = target;
        
        /// <summary>
        /// Set the timer lenght, when resetting it will use this number.
        /// </summary>
        /// <param name="target">The target amount for the timer</param>
        public void SetTimerLenght(float target) => _currentTimer = target;
        
        /// <summary>
        /// Get the timer it's current lenght.
        /// </summary>
        /// <returns>The current timer lenght</returns>
        public float GetCurrentTimerLenght() => _currentTimer;

        /// <summary>
        /// Calculates the percentage of the current timer relative to the progress.
        /// </summary>
        /// <returns>Return a number between 0-1</returns>
        public float GetCurrentTimerPercentage()
        {
            float hundredPercent = _isTimerLenghtSmall 
                ? _timerData.mainTimerLenght 
                : _timerData.smallTimerLenght;
            float currentPercent = _currentTimer / hundredPercent;
            return currentPercent;
        }

        /// <summary>
        /// Toggles the current timer to the big lenght if previously was small, otherwise in reverse.
        /// </summary>
        public void ToggleTimerLengthPreference()
        {
            _currentTimer = _isTimerLenghtSmall
                ? _timerData.mainTimerLenght
                : _timerData.smallTimerLenght;
            
            _isTimerLenghtSmall = !_isTimerLenghtSmall;
        }
        
        private void Counting()
        {
            if(!canCount)
                return;

            if (_isStarting)
            {
                _isStarting = false;
                onStart?.Invoke();
            }
            
            _currentTimer = isCountingUp 
                ? _currentTimer + Time.deltaTime 
                : _currentTimer - Time.deltaTime;
            
            switch (isCountingUp)
            {
                case false 
                when _currentTimer <= 0:
                    onTimerDone?.Invoke();
                    SetCanCount(false);
                    break;
                case true 
                when _currentTimer > timerThreshold:
                    onTimerPassedThreshold?.Invoke();
                    SetCanCount(false);
                    break;
            }
        }
    }
}