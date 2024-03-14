using FrameWork;
using FrameWork.Enums;
using Framework.Enums.GridPoints;
using FrameWork.Extensions;
using Player;
using UnityEngine;

namespace Framework.Cooking
{
    public sealed class KitchenAppliance : InteractableObject
    {
        private const string NEW_DISH_NAME = "New dish";
        
        [Header("References")]
        [SerializeField] private bool useTimer;
        [SerializeField] private GameObject newDishGameObject;
        [SerializeField] private Transform ingredientPosition;
        [SerializeField] private ItemHolding player;
        [SerializeField] private PlayerPoints thisPoint;
        
        [Header("Run time")]
        [SerializeField] private DishManager dishManager;
        [SerializeField] private IngredientObject ingredientObject;

        private bool _isAboutToBeInteracted;
        private Timer _timer;
        private GameObject _dishGameObject;

        private void Awake()
        {
            if (useTimer)
                _timer = GetComponent<Timer>();
        }

        /// <summary>
        /// If the player is close by it will pick-up a dish or give an ingredient depending on if it's empty.
        /// </summary>
        public void SetOrPickUpItem() => _isAboutToBeInteracted = true;
        
        private void Update()
        {
            if(!_isAboutToBeInteracted
               || player.transform.position != thisPoint.GetVector3())
                return;
            
            _isAboutToBeInteracted = false;
            CallSetOrPickUpItem();
        }

        /// <summary>
        /// Set the current ingredient if there is none. If already having one it can make a dish.
        /// </summary>
        public void SetIngredient()
        {
            if (!player.CurrentItem)
                return;
            
            HeldItem targetHeldItem = player.CurrentItem;
            IngredientObject targetIngredient = targetHeldItem.GetComponentInChildren<IngredientObject>();
            
            if (targetIngredient == null)
                targetIngredient = targetHeldItem as IngredientObject;
            
            player.CurrentItem = null;
            
            if (ingredientObject != null
                && ingredientObject.parent.CanMakeDish(targetIngredient))
            {
                FillDish(targetIngredient);
                ingredientObject = null;
                return;
            }

            if (ingredientObject != null)
                return;
            
            ingredientObject = targetIngredient;
            ingredientObject.transform.position = ingredientPosition.position;

            CreateDish();
            Grill();
        }

        /// <summary>
        /// Remove the current ingredient, sets it to null
        /// </summary>
        public void RemoveIngredient() => ingredientObject = null;

        /// <summary>
        /// Calls the ChangeState(IngredientState) with converting the int.
        /// </summary>
        /// <param name="targetState">The target state</param>
        public void ChangeCurrentIngredientState(int targetState)
            => ChangeCurrentIngredientState((IngredientState) targetState);
        
        /// <summary>
        /// Change the state to the next.
        /// RAW => BEING_PREPARED
        /// BEING_PREPARED => COOKED
        /// </summary>
        /// <param name="targetState">The target state</param>
        public void ChangeCurrentIngredientState(IngredientState targetState)
            => ingredientObject.ChangeState(targetState);
        
        /// <summary>
        /// Cook the fish
        /// </summary>
        public void CookFish() => ingredientObject.CookFish(ingredientObject);

        /// <summary>
        /// Give the current held item that is in this kitchen appliance, if there is any.
        /// </summary>
        public void GiveHeldItem()
        {
            if (player.CurrentItem)
                return;

            HeldItem heldItemToGive = null;

            if (dishManager)
                heldItemToGive = dishManager;
            
            if (heldItemToGive == null)
                return;
            
            player.SetHeldItem(heldItemToGive);
            dishManager = null;
            ingredientObject = null;
        }
        
        private void CallSetOrPickUpItem()
        {
            if (!player.CurrentItem)
                GiveHeldItem();
            else
                SetIngredient();
        }
        
        private void Grill()
        {
            if (!_timer) 
                return;
            
            if(ingredientObject.IngredientState == IngredientState.RAW)
                ChangeCurrentIngredientState(IngredientState.BEING_PREPARED);
            
            _timer.SetCanCount(true);
        }

        private void CreateDish()
        {
            _dishGameObject
                = Instantiate(newDishGameObject, ingredientPosition.position, ingredientPosition.rotation);
            _dishGameObject.transform.SetParent(transform);
            _dishGameObject.name = NEW_DISH_NAME;
            dishManager = _dishGameObject.GetComponent<DishManager>();
            dishManager.AddIngredient(ingredientObject);
        }

        private void FillDish(IngredientObject targetIngredient)
        {
            dishManager = ingredientObject.parent;
            dishManager.AddIngredient(ingredientObject);
            dishManager.AddIngredient(targetIngredient);
            dishManager.SetDishPosition(ingredientPosition.position);
            dishManager.transform.SetParent(transform);
        }
    }
}