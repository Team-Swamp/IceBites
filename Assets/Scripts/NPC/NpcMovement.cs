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
    }
}
