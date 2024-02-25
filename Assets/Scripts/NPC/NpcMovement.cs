using System;
using System.Collections;
using Framework;
using FrameWork.GridSystem;
using UnityEngine;

namespace NPC
{
    public sealed class NpcMovement : Movement
    {
        

        private void Start() => StartCoroutine(MovingNpc());
        
        public void MoveNpc(int points)
        {
            NpcPoints npcPoints = (NpcPoints)points;

            switch (npcPoints)
            {
                case NpcPoints.NPC_STARTING_POINT:
                    StartCoroutine(MoveTowardsGridPoint(NpcPoints.NPC_STARTING_POINT));
                    break;
                case NpcPoints.NPC_COUNTER_POINT:
                    StartCoroutine(MoveTowardsGridPoint(NpcPoints.NPC_COUNTER_POINT));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private IEnumerator MovingNpc()
        {
            while (true)
            {
                MoveNpc(1);
                yield return new WaitForSeconds(5);
                MoveNpc(0);
            }
        }
    }
}
