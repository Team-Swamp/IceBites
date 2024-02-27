using Framework;
using Framework.GridPoints;
using UnityEngine;
using UnityEngine.Events;

namespace Player.Movement
{
    public sealed class PlayerMovement : BaseMovement
    {
        [SerializeField] private UnityEvent activateMovingProtocol = new();
        
        /// <summary>
        /// Converts the Enums into an integer to be called in a Unity Event.
        /// </summary>
        /// <param name="playerPoints">Enum</param>
        public void StartMoving(int playerPoints) => StartMoving((PlayerPoints)playerPoints);
        
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
