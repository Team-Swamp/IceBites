using System;
using System.Collections;
using Framework;
using Framework.GridPoints;
using UnityEngine;

namespace NPC
{
    public sealed class NpcMovement : BaseMovement
    {
        private void Start() => StartCoroutine(MovingNpc());
        
        private IEnumerator MovingNpc()
        {
            while (true)
            {
                yield return StartCoroutine(MoveTowardsGridPoint(NpcPoints.NPC_COUNTER_POINT));
                yield return new WaitForSeconds(1);
                yield return StartCoroutine(MoveTowardsGridPoint(NpcPoints.NPC_STARTING_POINT));
                
            }
        }
    }
}
