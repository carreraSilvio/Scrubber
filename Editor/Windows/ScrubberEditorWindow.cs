using BrightLib.BrightEditing;
using UnityEditor;
using UnityEngine;

namespace BrightLib.Scrubbing.Editor
{
    /// <summary>
    /// Editor Window that mimics the default inspector
    /// </summary>
    public class ScrubberEditorWindow : EditorWindow
    {
        private SerializedObject _serializedObject;
        private SerializedProperty _currentProperty;

        internal SerializedObject SerializedObject { get => _serializedObject; set => _serializedObject = value; }
        internal SerializedProperty CurrentProperty { get => _currentProperty; set => _currentProperty = value; }

        public virtual void OnGUI()
        {
            DrawAllVisibleProperties();

            SerializedObject.ApplyModifiedProperties();
        }

        /// <summary>
        /// Draws all visible properties and the script field greyed out. Set <see cref="SerializedObject"/> first
        /// </summary>
        protected void DrawAllVisibleProperties()
        {
            if (_serializedObject == null) return;

            SerializedProperty prop = _serializedObject.GetIterator();
            if (prop.NextVisible(true))
            {
                do
                {
                    if (string.Equals(prop.name, "m_Script"))
                    {
                        GUI.enabled = false;
                        EditorGUILayout.PropertyField(prop, includeChildren: true);
                        GUI.enabled = true;
                    }
                    else
                    {
                        EditorGUILayout.PropertyField(prop, includeChildren: true);
                    }
                }
                while (prop.NextVisible(false));
            }
        }

        protected void DrawAllVisibleProperties(SerializedObject serializedObject, bool includeChildren = true)
        {
            SerializedProperty prop = serializedObject.GetIterator();
            if (prop.NextVisible(true))
            {
                do
                {
                    EditorGUILayout.PropertyField(prop, includeChildren: true);
                }
                while (prop.NextVisible(false));
            }
        }

    }
}