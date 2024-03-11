using FrameWork;
using Player;
using UnityEngine;

namespace Framework.Cooking
{
    public sealed class IngredientBasket : InteractableObject
    {
        [SerializeField] private GameObject ingredient;
        [SerializeField] private ItemHolding player;

        /// <summary>
        /// Give the selected ingredient to the player, by creating it.
        /// </summary>
        public void GiveIngredient()
        {
            if(player.CurrentItem)
                return;

            player.CreateHeldItem(ingredient);
        }
    }
}