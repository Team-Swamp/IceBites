using System;
using System.Reflection;
using UnityEngine;
using FrameWork.Attributes;

namespace FrameWork.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Get the string of an enum type.
        /// </summary>
        /// <param name="value">The enum that you want the string from.</param>
        /// <returns>The StringValue, if not existing returns empty string.</returns>
        public static string GetString(this Enum value)
        {
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());
            StringValue attribute = (StringValue)Attribute.GetCustomAttribute(fieldInfo, typeof(StringValue));

            return attribute?.Value ?? string.Empty;
        }
    
        /// <summary>
        /// Get the char of an enum type.
        /// </summary>
        /// <param name="value">The enum that you want the char from.</param>
        /// <returns>The CharValue, if not existing returns empty char ('\0').</returns>
        public static char GetChar(this Enum value)
        {
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());
            CharValue attribute = (CharValue)Attribute.GetCustomAttribute(fieldInfo, typeof(CharValue));

            return attribute?.Value ?? '\0'; // '\0' is a default value if the attribute is not found
        }
        
        /// <summary>
        /// Get the Vector2 of an enum type.
        /// </summary>
        /// <param name="value">The enum that you want the Vector2 from.</param>
        /// <returns>The Vector2Value, if not existing returns vector2.zero.</returns>
        public static Vector2 GetVector2(this Enum value)
        {
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());
            Vector2Value attribute = (Vector2Value)Attribute.GetCustomAttribute(fieldInfo, typeof(Vector2Value));

            return attribute?.Value ?? Vector2.zero;
        }
        
        /// <summary>
        /// Get the Vector3 of an enum type.
        /// </summary>
        /// <param name="value">The enum that you want the Vector3 from.</param>
        /// <returns>The Vector3Value, if not existing returns vector3.zero.</returns>
        public static Vector3 GetVector3(this Enum value)
        {
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());
            Vector3Value attribute = (Vector3Value)Attribute.GetCustomAttribute(fieldInfo, typeof(Vector3Value));

            return attribute?.Value ?? Vector3.zero;
        }
    }
}