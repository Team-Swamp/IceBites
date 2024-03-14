using FrameWork;
using Framework.Enums.GridPoints;
using FrameWork.Extensions;
using Player;
using UnityEngine;

namespace Framework.Cooking
{
    public sealed class IngredientBasket : InteractableObject
    {
        [SerializeField] private GameObject ingredient;

        [SerializeField] private ItemHolding player;
        [SerializeField] private PlayerPoints thisPoint;
        
        private bool _isAboutToBeInteracted;
        
        private void Update()
        {
            if(!_isAboutToBeInteracted
               || player.transform.position != thisPoint.GetVector3())
                return;
            
            _isAboutToBeInteracted = false;
            player.CreateHeldItem(ingredient);
        }
        
        /// <summary>
        /// Give the selected ingredient to the player, by creating it.
        /// </summary>
        public void GiveIngredient()
        {
            if(player.CurrentItem)
                return;

            _isAboutToBeInteracted = true;
        }
    }
}