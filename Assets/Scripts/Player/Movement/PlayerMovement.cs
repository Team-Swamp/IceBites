using System;
using System.Collections;
using FrameWork.Extensions;
using FrameWork.GridSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player.Movement
{
    public class PlayerMovement : MonoBehaviour
    { 
        public float movementSpeed;
        
        private int _enumLength;
        private int _index;

        private void Awake()
        {
            _enumLength = Enum.GetNames(typeof(GridPoints)).Length;
        }
        

        private IEnumerator MoveTowardsGridPoint()
        {
            print("loop");
            
            _index = (_index + 1) % _enumLength;
            GridPoints nextpoint = (GridPoints) _index;

            Vector3 newPos;
            newPos = nextpoint.GetVector3();
            while (transform.position != newPos)
            {
                transform.position = Vector3.MoveTowards(transform.position, newPos, movementSpeed * Time.deltaTime);
                yield return null;
            }
        }

        public void StartMoving()
        {
            StartCoroutine(MoveTowardsGridPoint());
        }

        /*public void ActivateBool()
        {
            Moving = true;
        }*/
    }
}
