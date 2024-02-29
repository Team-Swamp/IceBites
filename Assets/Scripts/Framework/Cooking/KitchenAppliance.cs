using FrameWork;
using FrameWork.Enums;
using UnityEngine;

namespace Framework.Cooking
{
    public sealed class KitchenAppliance : InteractableObject
    {
        [SerializeField] private bool useTimer;
        
        [SerializeField] private IngredientObject ingredientObject;
        [SerializeField] private Transform ingredientPosition;

        private Timer _timer;

        private void Awake()
        {
            if (useTimer)
                _timer = GetComponent<Timer>();
        }

        /// <summary>
        /// Set the current ingredient if there is none
        /// </summary>
        /// <param name="targetIngredient"></param>
        public void SetIngredient(IngredientObject targetIngredient)
        {
            if(ingredientObject != null)
                return;

            ingredientObject = targetIngredient;
            ingredientObject.transform.position = ingredientPosition.position;
            ChangeCurrentIngredientState(IngredientState.BEING_PREPARED);
            
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
        public void ChangeCurrentIngredientState(int targetState) => ChangeCurrentIngredientState((IngredientState) targetState);
        
        /// <summary>
        /// Change the state to the next.
        /// RAW => BEING_PREPARED
        /// BEING_PREPARED => COOKED
        /// </summary>
        /// <param name="targetState">The target state</param>
        public void ChangeCurrentIngredientState(IngredientState targetState) => ingredientObject.ChangeState(targetState);
        
        /// <summary>
        /// Cook the fish
        /// </summary>
        public void CookFish() => ingredientObject.CookFish(ingredientObject);
        
        private void Grill()
        {
            if (!_timer) 
                return;
            
            _timer.SetCanCount(true);
        }
    }
}