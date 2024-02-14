using System;
using System.Collections;
using FrameWork.Extensions;
using FrameWork.GridSystem;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Player.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        
        [SerializeField, Range(1,10)] private float movementSpeed; 
        [SerializeField] private UnityEvent startedMoving = new();
        
        private int _enumLength;
        private int _gridIndex;

        private bool _moving;

        private void Awake()=> _enumLength = Enum.GetNames(typeof(PlayerGridPoints)).Length;
        
        private IEnumerator MoveTowardsGridPoint(PlayerGridPoints points)
        {
            if (!_moving)
            {
                PlayerGridPoints playerGridPoint = points;
                
                Vector3 newPos = playerGridPoint.GetVector3();
                while (transform.position != newPos)
                {
                    _moving = true;
                    transform.position = Vector3.MoveTowards(transform.position, newPos, movementSpeed * Time.deltaTime);
                    yield return null;
                }

                _moving = false;
            }
        } 
        /// <summary>
        /// Starts the coroutine to start moving the player from point A > The next point
        /// </summary>
        public void StartMoving(int playerPoints)
        {
            PlayerGridPoints points = (PlayerGridPoints)playerPoints;
            switch (points)
            {
                case PlayerGridPoints.POINT_A:
                    StartCoroutine(MoveTowardsGridPoint(PlayerGridPoints.POINT_A));
                    break;
                case PlayerGridPoints.POINT_B:
                    StartCoroutine(MoveTowardsGridPoint(PlayerGridPoints.POINT_B));
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
