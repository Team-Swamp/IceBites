using FrameWork.Enums;
using UnityEngine;
using UnityEngine.Events;

namespace Framework.Cooking
{
    public sealed class IngredientObject : HeldItem
    {
        [HideInInspector] public DishManager parent;
        
        [SerializeField] private Ingredient ingredient;

        [SerializeField] private Material cookedMat;

        private IngredientState _state;

        public Ingredient Ingredient => ingredient;
        
        public IngredientState IngredientState => _state;

        [SerializeField] private UnityEvent onBeingPrepared = new();
        [SerializeField] private UnityEvent onCooked = new();

        /// <summary>
        /// Calls the ChangeState(IngredientState) with converting the int.
        /// </summary>
        /// <param name="targetState">The target state</param>
        public void ChangeState(int targetState) => ChangeState((IngredientState) targetState);
        
        /// <summary>
        /// Change the state to the next.
        /// RAW => BEING_PREPARED
        /// BEING_PREPARED => COOKED
        /// </summary>
        /// <param name="targetState">The target state</param>
        public void ChangeState(IngredientState targetState)
        {
            switch (_state)
            {
                case IngredientState.RAW 
                when targetState == IngredientState.BEING_PREPARED:
                    _state = IngredientState.BEING_PREPARED;
                    onBeingPrepared?.Invoke();
                    break;
                case IngredientState.BEING_PREPARED 
                when targetState == IngredientState.COOKED:
                    _state = IngredientState.COOKED;
                    onCooked?.Invoke();
                    break;
                case IngredientState.COOKED:
                default:
                    Debug.LogError($"Invalid target state '{targetState}' when state is '{_state}'.");
                    break;
            }
        }

        /// <summary>
        /// Cooks the fish.
        /// </summary>
        /// <param name="fish">The IngredientObject that should be a raw fish</param>
        public void CookFish(IngredientObject fish)
        {
            if (fish.ingredient != Ingredient.FISH_RAW)
                return;
            
            GetComponentInChildren<MeshRenderer>().material = cookedMat;
            fish.ingredient = Ingredient.FISH_COOKED;
        }
    }
}