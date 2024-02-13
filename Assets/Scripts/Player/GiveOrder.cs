using System;
using FrameWork.Enums;
using NPC;
using UnityEngine;

namespace Player
{
    public sealed class GiveOrder : MonoBehaviour
    {
        [SerializeField] private NpcOrdering npc;
        [SerializeField] private bool order;
        [SerializeField] private bool get;
        [SerializeField] private Dish giveDish;
        [SerializeField] private Dish[] orders;
        
        private void Update()
        {
            if (order)
            {
                npc.DeliverOrder(giveDish);
                order = !order;
            }

            if (get)
            {
                orders = npc.GetOrder();
                get = !get;
            }
        }
    }
}