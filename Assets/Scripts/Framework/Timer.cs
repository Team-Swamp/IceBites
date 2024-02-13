using UnityEngine;
using UnityEngine.Events;

namespace FrameWork
{
    public sealed class Timer : MonoBehaviour
    {
        [SerializeField] private float startingTime;
        [SerializeField] private bool canCountDown;

        private float _currentTimer;

        [SerializeField] private UnityEvent onTimerDone = new();
        [SerializeField] private UnityEvent onReset = new();

        private void Awake() => ResetTimer();

        private void Update() => CountDown();

        /// <summary>
        /// Reset the timer to startingTime and calls the onReset event.
        /// </summary>
        public void ResetTimer()
        {
            _currentTimer = startingTime;
            onReset?.Invoke();
        }

        /// <summary>
        /// Set the timer lenght, when resetting it will use this number.
        /// </summary>
        /// <param name="target">The target amount for the timer</param>
        public void SetTimerLenght(float target) => startingTime = target;
        
        private void CountDown()
        {
            if(!canCountDown)
                return;

            _currentTimer -= Time.deltaTime;
            
            if (_currentTimer <= 0)
                onTimerDone?.Invoke();
        }
    }
}