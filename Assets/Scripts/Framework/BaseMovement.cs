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
        /// <typeparam name="T">Enum.</typeparam>
        /// <returns></returns>
        protected IEnumerator MoveTowardsGridPoint<T>(T points) where T: Enum
        {
            Vector3 newPos = points.GetVector3();
            while (transform.position != newPos)
            {
                transform.position = Vector3.MoveTowards(transform.position, newPos, p_movementSpeed * Time.deltaTime);
                yield return null;
            }
            onStopMoving?.Invoke();
        } 
    }
}
