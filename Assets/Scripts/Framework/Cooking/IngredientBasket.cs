using FrameWork;
using Player;
using UnityEngine;

namespace Framework.Cooking
{
    public sealed class IngredientBasket : InteractableObject
    {
        [SerializeField] private GameObject ingredient;
        [SerializeField] private ItemHolding player;

        public void GiveIngredient()
        {
            if(player.CurrentItem)
                return;

            player.CreateHeldItem(ingredient);
        }
    }
}