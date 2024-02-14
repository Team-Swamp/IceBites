using FrameWork.Enums;
using UnityEngine;

namespace FrameWork.ScriptableObjects
{
    [CreateAssetMenu(fileName = "newNpcOder", menuName = "VooDoo/NPC", order = 0)]
    public sealed class NpcOder : ScriptableObject
    {
        [SerializeField] private Dish[] orders;
        
        public Dish[] Orders => orders;
    }
}