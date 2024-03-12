using Framework.Cooking;
using UnityEngine;

namespace Player
{
    public sealed class ItemHolding : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform heldItemPosition;
        
        [Header("Runtime")]
        [SerializeField] private HeldItem currentItem;

        public HeldItem CurrentItem
        {
            get => currentItem;
            set => currentItem = value;
        }

        /// <summary>
        /// If holding none it will hold the given target. Is also updates the position and parent object.
        /// </summary>
        /// <param name="targetHeldItem">The target held item to hold</param>
        public void SetHeldItem(HeldItem targetHeldItem)
        {
            if(CurrentItem)
                return;

            currentItem = targetHeldItem;
            currentItem.transform.position = heldItemPosition.position;
            currentItem.transform.SetParent(heldItemPosition);
        }

        /// <summary>
        /// Create a game object with the held item class.
        /// </summary>
        /// <param name="targetHeldItem">Target held item game object</param>
        public void CreateHeldItem(GameObject targetHeldItem)
        {
            if(CurrentItem)
                return;

            GameObject heldItem = Instantiate(targetHeldItem);
            SetHeldItem(heldItem.GetComponent<HeldItem>());
        }
    }
}