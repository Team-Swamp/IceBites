using Framework;
using Framework.Enums.GridPoints;
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
        /// Starts a unity event to call the coroutine for moving the player. This allows for us to choose which point the player moves with unity events
        /// </summary>
        public void StartMovingEvent() => activateMovingProtocol.Invoke();
    }
}
