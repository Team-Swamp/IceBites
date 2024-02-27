using System;
using UnityEngine;
using FrameWork.Enums;

namespace FrameWork.ScriptableObjects
{
    [CreateAssetMenu(fileName = "newNpcOrder", menuName = "VooDoo/NPC", order = 0)]
    public sealed class NpcOrder : ScriptableObject
    {
        [SerializeField] private Dish[] orders;

        public Dish[] Orders => orders;
    }
}