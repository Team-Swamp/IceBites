using System;
using UnityEngine;

namespace FrameWork.Attributes
{
    public sealed class Vector3Value : Attribute
    {
        public Vector3 Value { get; }

        public Vector3Value(float x, float y, float z) => Value = new Vector3(x, y, z);
    }
}