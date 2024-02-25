using System;
using System.Collections;
using FrameWork.Extensions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Framework
{
    public abstract class Movement : MonoBehaviour
    {
        [SerializeField,Range(1,10)] protected float p_movementSpeed; 

        private bool _isMoving;
        
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
            if (!_isMoving)
            {
                
                Vector3 newPos = points.GetVector3();
                while (!newPos.Compare(transform.position))
                {
                    _isMoving = true;
                    transform.position = Vector3.MoveTowards(transform.position, newPos, p_movementSpeed * Time.deltaTime);
                    yield return null;
                }

                _isMoving = false;
            }
        } 
    }
}
