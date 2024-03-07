using Framework;
using Framework.GridPoints;
using UnityEngine;
using UnityEngine.Events;

namespace Player.Movement
{
    public sealed class PlayerMovement : BaseMovement
    {
        [SerializeField] private UnityEvent activateMovingProtocol = new();

        private bool _hasWalked;
        
        /// <summary>
        /// Converts the Enums into an integer to be called in a Unity Event.
        /// </summary>
        /// <param name="playerPoints">Enum</param>
        public void StartMoving(int playerPoints) => StartMoving((PlayerPoints)playerPoints);

        /// <summary>
        /// A test function to toggle the walk point.
        /// </summary>
        public void StartMoving()
        {
            StartMoving(_hasWalked ? PlayerPoints.POINT_B : PlayerPoints.POINT_C);
            _hasWalked = !_hasWalked;
        }
        
        /// <summary>
        /// Moves the player from it's starting position towards the newly designated position.
        /// </summary>
        /// <param name="targetPoint"></param>
        public void StartMoving(PlayerPoints targetPoint)
        {
            onStartedMoving?.Invoke();
            StartCoroutine(MoveTowardsGridPoint(targetPoint));
        }

        /// <summary>
        /// Starts a unity event to call the coroutine for moving the player. This allows for us to choose which point the player moves with unity events
        /// </summary>
        public void StartMovingEvent() => activateMovingProtocol.Invoke();
    }
}
