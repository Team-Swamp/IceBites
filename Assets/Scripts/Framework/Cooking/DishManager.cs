using System.Collections.Generic;
using FrameWork.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace Framework.Cooking
{
    public sealed class DishManager : MonoBehaviour
    {
        [SerializeField] private GameObject displayDish;
        [SerializeField] private List<IngredientObject> ingredients = new();
        
        [SerializeField] private UnityEvent onDishMade = new();
        
        /// <summary>
        /// Add an ingredient to a dish. If it's the second one it will transform into a dish model.
        /// </summary>
        /// <param name="target">The target IngredientObject to add</param>
        public void AddIngredient(IngredientObject target)
        {
            if (ingredients.Count >= 2 
                || ingredients.Contains(target))
                return;

            ingredients.Add(target);
            SetParent();
            
            if (ingredients.Count == 2)
                MakeDish();
        }

        /// <summary>
        /// Check if the this can be made.
        /// </summary>
        /// <param name="target">The second ingredient to check</param>
        /// <returns>True if the ingredients can be made into a dish, other wise it can not</returns>
        public bool CanMakeDish(IngredientObject target)
        {
            ingredients.Add(target);
            (bool canMakeDish, GameObject dishToShow) = CanMakeDish();
            ingredients.Remove(target);
            
            return canMakeDish;
        }

        /// <summary>
        /// Set the position of this dish.
        /// </summary>
        /// <param name="targetPos">Target position for this dish</param>
        public void SetDishPosition(Vector3 targetPos) =>  transform.position = targetPos;
        
        private void MakeDish()
        {
            (bool canMakeDish, GameObject dishToShow) = CanMakeDish();
            
            if (!canMakeDish)
            {
                Debug.LogWarning($"Cannot make a dish with these ingredients. {ingredients[0]} {ingredients[1]}");
                return;
            }
            
            if (!dishToShow)
            {
                Debug.LogError($"Cannot show dish. {ingredients[0]} {ingredients[1]}");
                return;
            }
            
            foreach (var ingredient in ingredients) 
                Destroy(ingredient.gameObject);

            displayDish = Instantiate(dishToShow, ingredients[0].transform.position, Quaternion.identity, transform);
            
            ingredients.Clear();
            onDishMade?.Invoke();
        }
        
        private (bool, GameObject) CanMakeDish()
        {
            IEnumerable<Recipe> recipes = RecipesHolder.Instance.Recipes;
            
            foreach (var recipe in recipes)
            {
                bool isValidCombination = ingredients[0].Ingredient == recipe.firstIngredient
                                          && ingredients[1].Ingredient == recipe.secondIngredient 
                                          || ingredients[0].Ingredient == recipe.secondIngredient 
                                          && ingredients[1].Ingredient == recipe.firstIngredient;

                if (!isValidCombination)
                    continue;

                gameObject.name = recipe.name;
                GameObject modelToShow = recipe.dishModel;
                return (true, modelToShow);
            }
            
            return (false, null);
        }

        private void SetParent()
        {
            if(ingredients.Count != 1)
                return;
            
            ingredients[0].transform.SetParent(transform);
            ingredients[0].parent = this;   
        }
    }
}
