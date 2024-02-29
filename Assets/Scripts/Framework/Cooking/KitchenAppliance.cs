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

        public void SetIngredient(IngredientObject targetIngredient)
        {
            if(ingredientObject != null)
                return;

            ingredientObject = targetIngredient;
            ingredientObject.transform.position = ingredientPosition.position;
            ChangeCurrentIngredientState(IngredientState.BEING_PREPARED);
            
            Grill();
        }

        public void RemoveIngredient() => ingredientObject = null;

        public void ChangeCurrentIngredientState(int target) => ChangeCurrentIngredientState((IngredientState) target);
        public void ChangeCurrentIngredientState(IngredientState target) => ingredientObject.ChangeState(target);
        
        public void CookFish() => ingredientObject.CookFish(ingredientObject);
        
        private void Grill()
        {
            if (!_timer) 
                return;
            
            _timer.SetCanCount(true);
        }
    }
}