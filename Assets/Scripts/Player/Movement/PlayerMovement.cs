using System;
using FrameWork.GridSystem;

namespace Player.Movement
{
    public sealed class PlayerMovement : Framework.Movement
    {
        /// <summary>
        /// Calls the coroutine to start moving the player from it's current position to a newly assigned one.
        /// </summary>
        public void StartMoving(int playerPoints)
        {
            PlayerPoints points = (PlayerPoints)playerPoints;
            switch (points)
            {
                case PlayerPoints.POINT_A:
                    StartCoroutine(MoveTowardsGridPoint(PlayerPoints.POINT_A));
                    break;
                case PlayerPoints.POINT_B:
                    StartCoroutine(MoveTowardsGridPoint(PlayerPoints.POINT_B));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Starts a unity event to call the coroutine for moving the player. This allows for us to choose which point the player moves with unity events
        /// </summary>
        public void StartMovingEvent() => onStartedMoving.Invoke();
    }
}
