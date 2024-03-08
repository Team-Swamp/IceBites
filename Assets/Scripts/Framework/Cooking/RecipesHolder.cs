using System.Collections.Generic;
using FrameWork.ScriptableObjects;
using UnityEngine;

namespace Framework.Cooking
{
    public sealed class RecipesHolder : Singleton<RecipesHolder>
    {
        [SerializeField] private Recipe[] recipes;

        public IEnumerable<Recipe> Recipes => recipes;
    }
}