using System;
using UnityEngine;

namespace FrameWork.Attributes
{
    public sealed class Vector2Value : Attribute
    {
        public Vector2 Value { get; }

        public Vector2Value(Vector2 value) => Value = value;
    }
}