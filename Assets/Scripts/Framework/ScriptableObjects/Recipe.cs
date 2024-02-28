using FrameWork.Enums;
using UnityEngine;

namespace FrameWork.ScriptableObjects
{
    [CreateAssetMenu(fileName = "newRecipe", menuName = "VooDoo/Recipe", order = 0)]
    public sealed class Recipe : ScriptableObject
    {
        public Ingredient firstIngredient;
        public Ingredient secondIngredient;
        public GameObject dishModel;
    }
}