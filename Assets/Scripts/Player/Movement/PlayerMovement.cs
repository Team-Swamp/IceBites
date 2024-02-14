using System;
using System.Collections;
using FrameWork.Extensions;
using FrameWork.GridSystem;
using UnityEngine;

namespace Player.Movement
{
    public sealed class PlayerMovement : MonoBehaviour
    { 
        [SerializeField, Range(1,10)] private float movementSpeed;
        
        private int _enumLength;
        private int _gridIndex;

        private void Awake()=> _enumLength = Enum.GetNames(typeof(GridPoints)).Length;
        
        private IEnumerator MoveTowardsGridPoint()
        {
            _gridIndex = (_gridIndex + 1) % _enumLength;
            GridPoints nextpoint = (GridPoints) _gridIndex;

            Vector3 newPos;
            newPos = nextpoint.GetVector3();
            while (transform.position != newPos)
            {
                transform.position = Vector3.MoveTowards(transform.position, newPos, movementSpeed * Time.deltaTime);
                yield return null;
            }
        }
        /// <summary>
        /// Starts the coroutine to start moving the player from point A > The next point
        /// </summary>
        public void StartMoving() => StartCoroutine(MoveTowardsGridPoint());
    }
}
