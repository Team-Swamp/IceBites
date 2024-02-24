using System;
using FrameWork.GridSystem;
using UnityEngine;
using UnityEngine.Events;

namespace Player.Movement
{
    public class PlayerMovement : Framework.Movement
    {
        [SerializeField, Range(1,10)] private float movementSpeed; 

        [SerializeField] private UnityEvent startedMoving = new();
        private void Start()
        {
            MovementSpeed = movementSpeed;
        }

        /// <summary>
        /// Starts the coroutine to start moving the player from point A > The next point
        /// </summary>
        public void StartMoving(int playerPoints)
        {
            GridPoints.PlayerPoints points = (GridPoints.PlayerPoints)playerPoints;
            switch (points)
            {
                case GridPoints.PlayerPoints.POINT_A:
                    StartCoroutine(MoveTowardsGridPoint(GridPoints.PlayerPoints.POINT_A));
                    break;
                case GridPoints.PlayerPoints.POINT_B:
                    StartCoroutine(MoveTowardsGridPoint(GridPoints.PlayerPoints.POINT_B));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Starts a unity event to call the coroutine for moving the player. This allows for us to choose which point the player moves with unity events
        /// </summary>
        public void StartMovingEvent() => startedMoving.Invoke();
    }
}
