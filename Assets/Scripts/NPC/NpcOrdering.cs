using FrameWork;
using FrameWork.Enums;
using FrameWork.Extensions;
using FrameWork.ScriptableObjects;
using UnityEngine;

namespace NPC
{
    public sealed class NpcOrdering : MonoBehaviour
    {
        [Header("References")]
        [SerializeReference] private Timer timer;
        
        [Header("Order")]
        [SerializeField] private NpcOrder dishToOrder;

        private bool _hasOrder;
        private int _currentOrder;
        private int _correctDishes;

        private void Awake() => FillOrder();

        /// <summary>
        /// Give the a order to the NPC.
        /// </summary>
        /// <param name="target">The target dish to deliver</param>
        public void DeliverOrder(Dish target)
        {
            if(_hasOrder)
                return;

            if (target == dishToOrder.Orders[_currentOrder])
                _correctDishes++;
            
            _currentOrder++;

            if (_currentOrder == dishToOrder.Orders.Length)
                SendNpcAway();
        }

        public Dish[] GetOrder()
        {
            timer.SetCanCount(true);
            return dishToOrder.Orders;
        }

        /// <summary>
        /// Set the score for the player with this NPC and send it away.
        /// </summary>
        public void SendNpcAway()
        {
            timer.SetCanCount(false);
            _hasOrder = true;
            ScoreManager.Instance.IncreaseScore(SetScore());
            print($"Npc walks away.");
            //todo: NPC walk away
        }

        private int SetScore() => (int) timer.GetCurrentTimerLenght() * _correctDishes;
        
        private void FillOrder()
        {
            int lenght = dishToOrder.Orders.Length;
            for (int i = 0; i < lenght; i++)
            {
                if (dishToOrder.Orders[i] == Dish.NONE)
                    dishToOrder.Orders[i] = EnumExtensions.GetRandomEnumValue<Dish>();   
            }
        }
    }
}