using System;
using UnityEngine;

namespace FrameWork.Attributes
{
    public sealed class Vector3Value : Attribute
    {
        public Vector3 Value { get; }

        public Vector3Value(Vector3 value) => Value = value;
    }
}