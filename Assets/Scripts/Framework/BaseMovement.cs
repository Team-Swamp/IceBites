using System;
using System.Collections;
using FrameWork.Extensions;
using UnityEngine;
using UnityEngine.Events;

namespace Framework
{
    public abstract class BaseMovement : MonoBehaviour
    {
        [SerializeField,Range(1,10)] protected float p_movementSpeed; 
        
        [SerializeField] protected UnityEvent onStartedMoving = new();
        [SerializeField] protected UnityEvent onStopMoving = new();
        
        /// <summary>
        /// This function moves the object (player or NPC) from it's starting position over towards the designated position.
        /// </summary>
        /// <param name="points">Points is the parameter for one of the enum's in the GridPoints structure</param>
        /// <typeparam name="T">Enum with gird point</typeparam>
        protected IEnumerator MoveTowardsGridPoint<T>(T points) where T: Enum
        {
            Vector3 newPos = points.GetVector3();
            RotateToWalkPoint(newPos);

            while (transform.position != newPos)
            {
                transform.position = Vector3.MoveTowards(transform.position, newPos, p_movementSpeed * Time.deltaTime);
                yield return null;
            }
            
            onStopMoving?.Invoke();
        } 
        
        /// <summary>
        /// This will invoke the onStartedMoving event with the enum that is given to it.
        /// </summary>
        /// <param name="targetPoint">The enum containing the list of grid points</param>
        /// <typeparam name="T">This is an enum type.</typeparam>
        protected void StartMoving<T>(T targetPoint) where T: Enum
        {
            onStartedMoving?.Invoke();
            StartCoroutine(MoveTowardsGridPoint(targetPoint));
        }
        
        private void RotateToWalkPoint(Vector3 newPos)
        {
            Vector3 direction = new Vector3(newPos.x - transform.position.x, 0f, newPos.z - transform.position.z);
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Euler(0f, targetRotation.eulerAngles.y, 0f);
        }
    }
}
