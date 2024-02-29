using Framework.Cooking;
using UnityEditor;

namespace Editor
{
    [CustomEditor(typeof(IngredientObject))]
    public sealed class IngredientObjectEditor : UnityEditor.Editor
    {
        private SerializedProperty _ingredient;
        private SerializedProperty _cookedMat;
        private SerializedProperty _onBeingPrepared;
        private SerializedProperty _onCooked;

        /// <summary>
        /// Display every serialized variable/events.
        /// If the ingredient is "FISH_RAW" then we will show cooked material.
        /// </summary>
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            EditorGUILayout.PropertyField(_ingredient);
            
            if(_ingredient.enumValueIndex == 1) 
                EditorGUILayout.PropertyField(_cookedMat);
            
            EditorGUILayout.Space(20);
            EditorGUILayout.PropertyField(_onBeingPrepared);
            EditorGUILayout.PropertyField(_onCooked);
    
            serializedObject.ApplyModifiedProperties();
        }
        
        private void OnEnable()
        {
            _ingredient = serializedObject.FindProperty("ingredient");
            _cookedMat = serializedObject.FindProperty("cookedMat");
            _onBeingPrepared = serializedObject.FindProperty("onBeingPrepared");
            _onCooked = serializedObject.FindProperty("onCooked");
        }
    }
}