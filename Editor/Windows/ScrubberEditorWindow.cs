﻿using UnityEditor;
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
        private Vector2 _scrollPosition;

        internal SerializedObject SerializedObject { get => _serializedObject; set => _serializedObject = value; }
        internal SerializedProperty CurrentProperty { get => _currentProperty; set => _currentProperty = value; }

        public virtual void OnGUI()
        {
            if (_serializedObject == null)
            {
                return;
            }
            DrawAllVisibleProperties();

            SerializedObject.ApplyModifiedProperties();
        }

        /// <summary>
        /// Draws all visible properties and the script field greyed out. Set <see cref="SerializedObject"/> first
        /// </summary>
        protected void DrawAllVisibleProperties()
        {

            SerializedProperty prop = _serializedObject.GetIterator();
            if (prop.NextVisible(true))
            {
                _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition);
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
                EditorGUILayout.EndScrollView();
            }
        }

    }
}
