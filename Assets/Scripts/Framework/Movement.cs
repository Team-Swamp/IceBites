using System;
using System.Collections;
using FrameWork.Extensions;
using UnityEngine;
using UnityEngine.Serialization;

namespace Framework
{
    public abstract class Movement : MonoBehaviour
    {
        [Range(1,10)] public float MovementSpeed; 

        private bool _moving;

        protected IEnumerator MoveTowardsGridPoint<T>(T points) where T: Enum
        {
            if (!_moving)
            {
                
                Vector3 newPos = points.GetVector3();
                while (transform.position != newPos)
                {
                    _moving = true;
                    transform.position = Vector3.MoveTowards(transform.position, newPos, MovementSpeed * Time.deltaTime);
                    yield return null;
                }

                _moving = false;
            }
        } 
    }
}
