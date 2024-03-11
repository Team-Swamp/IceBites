using FrameWork;
using FrameWork.Enums;
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

        [Header("Run time")]
        [SerializeField] private DishManager dishManager;
        [SerializeField] private IngredientObject ingredientObject;

        private Timer _timer;
        private GameObject _dishGameObject;

        private void Awake()
        {
            if (useTimer)
                _timer = GetComponent<Timer>();
        }

        /// <summary>
        /// Set the current ingredient if there is none
        /// </summary>
        /// <param name="targetIngredient">The target ingredient to set as current.</param>
        public void SetIngredient(IngredientObject targetIngredient)
        {
            if (targetIngredient.parent != null
                && ingredientObject != null
                && targetIngredient.parent.CanMakeDish(ingredientObject))
            {
                Destroy(_dishGameObject);
                dishManager = null;
                FillDish(targetIngredient);
                ingredientObject = null;
                return;
            }

            if(ingredientObject != null)
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

        public void GiveHeldItem()
        {
            if (player.CurrentItem)
            {
                Debug.Log("q3uihsdcio");
                return;
            }

            HeldItem heldItemToGive = null;

            if (dishManager
                && ingredientObject == null)
                heldItemToGive = dishManager;
            else if (dishManager == null
                     && ingredientObject)
                heldItemToGive = ingredientObject;

            if (heldItemToGive != null)
            {
                Debug.Log(heldItemToGive.name);
                player.SetHeldItem(heldItemToGive);
            }
            else
                Debug.LogWarning("");
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
            dishManager = targetIngredient.parent;
            dishManager.AddIngredient(ingredientObject);
            dishManager.AddIngredient(targetIngredient);
            dishManager.SetDishPosition(ingredientPosition.position);
            dishManager.transform.SetParent(transform);
        }
    }
}