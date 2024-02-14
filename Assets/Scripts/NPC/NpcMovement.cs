using System;
using System.Collections;
using FrameWork.Extensions;
using FrameWork.GridSystem;
using UnityEngine;

namespace NPC
{
    public class NpcMovement : MonoBehaviour
    {
        [SerializeField, Range(1, 10)] private float movementSpeed;
        
        private int _enumLength;
        private int _gridIndex;

        private bool _moving;
        private void Awake() => _enumLength = Enum.GetNames(typeof(NpcGridpoints)).Length;

        private void Update() => MoveNpc();

        private IEnumerator MovementNpc()
        {
            if (!_moving)
            {
                _gridIndex = (_gridIndex + 1) % _enumLength;
                NpcGridpoints npcGridpoints = (NpcGridpoints) _gridIndex;

                Vector3 nextPos = npcGridpoints.GetVector3();
                while (transform.position != nextPos)
                {
                    _moving = true;
                    transform.position = Vector3.MoveTowards(transform.position, nextPos, movementSpeed * Time.deltaTime);
                    yield return null;
                }

                _moving = false;
            }
        }
        private void MoveNpc() => StartCoroutine(MovementNpc());
    }
}
