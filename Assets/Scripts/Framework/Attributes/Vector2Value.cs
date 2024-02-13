using System;
using UnityEngine;

namespace FrameWork.Attributes
{
    public sealed class Vector2Value : Attribute
    {
        public Vector2 Value { get; }

        public Vector2Value(float x, float y) => Value = new Vector2(x,y);
    }
}