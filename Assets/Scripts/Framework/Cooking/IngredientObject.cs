using FrameWork.Enums;
using UnityEngine;
using UnityEngine.Events;

namespace Framework.Cooking
{
    public sealed class IngredientObject : MonoBehaviour
    {
        [SerializeField] private Ingredient ingredient;

        [SerializeField] private Material cookedMat;
        
        private IngredientState _state;

        public Ingredient Ingredient => ingredient;

        [SerializeField] private UnityEvent onBeingPrepared = new();
        [SerializeField] private UnityEvent onCooked = new();

        public void ChangeState(int targetState) => ChangeState((IngredientState) targetState);
        
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

        public void CookFish(IngredientObject fish)
        {
            if (fish.ingredient != Ingredient.FISH_RAW)
                return;
            
            fish.ingredient = Ingredient.FISH_COOKED;
            SetMaterialCooked(fish);
        }

        private void SetMaterialCooked(IngredientObject fish)
        {
            GetComponent<MeshRenderer>().material = cookedMat;
        }
    }
}