using UnityEngine;
using UnityEngine.Events;

namespace FrameWork
{
    public abstract class InteractableObject : MonoBehaviour
    {
        public UnityEvent onInteract = new();
    }
}