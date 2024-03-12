using System;
using System.Collections;
using Framework;
using Framework.GridPoints;
using UnityEngine;

namespace NPC
{
    public sealed class NpcMovement : BaseMovement
    {
        /// <summary>
        /// Converts the Enums into an integer to be called in a Unity Event.
        /// </summary>
        /// <param name="npcPoints">Enum</param>
        public void StartMoving(int npcPoints) => StartMoving((NpcPoints)npcPoints);
        
        /// <summary>
        /// Moves the NPC from it's starting position towards the newly designated position.
        /// </summary>
        /// <param name="targetPoint"></param>
        public void StartMoving(NpcPoints targetPoint)
        {
            StartCoroutine(MoveTowardsGridPoint(targetPoint));
            onStartedMoving?.Invoke();
        }
    }
}
