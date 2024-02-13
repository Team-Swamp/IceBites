using FrameWork.Enums;
using FrameWork.Extensions;
using FrameWork.ScriptableObjects;
using UnityEngine;

namespace NPC
{
    public sealed class NpcOrdering : MonoBehaviour
    {
        [SerializeField] private NpcOrder dishToOrder;

        private bool _hasOrder;
        private int _currentOrder;

        private void Awake() => FillOrder();

        public void DeliverOrder(Dish target)
        {
            if(_hasOrder)
                return;
            
            if (target == dishToOrder.Orders[_currentOrder])
                print("Very good");
            else
                print("Ew, not what I ordered");

            _currentOrder++;

            if (_currentOrder == dishToOrder.Orders.Length)
                _hasOrder = true;
        }

        public Dish[] GetOrder() => dishToOrder.Orders;
        
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