using JetBrains.Annotations;
using Player.Input_Parser;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class InteractableObject : MonoBehaviour
    {
        public UnityEvent onInteract = new();
        
        /// <Summary>
        /// Does the basic interact function
        /// </Summary>
        /// <param name="heldItem"> Checks for the item held by the player </param>
        public void Interact(GameObject heldItem)
        {
            
            Debug.Log("Working");
        }
    }
}