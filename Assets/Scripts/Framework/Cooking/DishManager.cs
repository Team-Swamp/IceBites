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
        /// <param name="target"></param>
        public void AddIngredient(IngredientObject target)
        {
            if (ingredients.Count >= 2 
                || ingredients.Contains(target))
                return;

            ingredients.Add(target);

            if (ingredients.Count == 2)
                MakeDish();
        }

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

            Debug.Log("Dish made with ingredients:");
            foreach (var ingredient in ingredients)
            {
                Debug.Log(ingredient.Ingredient);
                Destroy(ingredient.gameObject);
            }

            displayDish = Instantiate(dishToShow, ingredients[0].transform.position, Quaternion.identity);
            
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
                
                GameObject modelToShow = recipe.dishModel;
                return (true, modelToShow);
            }
            
            return (false, null);
        }
    }
}
