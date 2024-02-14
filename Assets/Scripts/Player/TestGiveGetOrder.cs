using FrameWork.Enums;
using NPC;
using UnityEngine;

namespace Player
{
    /// <summary>
    /// Test class. Later would be replaced or rework when player can walk in the kitchen.
    /// </summary>
    public sealed class TestGiveGetOrder : MonoBehaviour
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