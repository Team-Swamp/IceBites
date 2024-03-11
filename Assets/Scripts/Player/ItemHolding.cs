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

        public void SetHeldItem(HeldItem targetItem)
        {
            if(CurrentItem)
                return;

            Debug.Log("gewugyuiwerigyuewiguweyuiuyiweukygfuyigweugfyiewuigyfugyiweugyi");
            currentItem = targetItem;
            currentItem.transform.position = heldItemPosition.position;
            currentItem.transform.SetParent(heldItemPosition);
        }

        public void CreateHeldItem(GameObject targetHeldItem)
        {
            if(CurrentItem)
                return;

            GameObject heldItem = Instantiate(targetHeldItem);
            SetHeldItem(heldItem.GetComponent<HeldItem>());
        }

        public void GiveHeldItem()
        {
            
        }
    }
}