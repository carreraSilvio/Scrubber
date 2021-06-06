using UnityEditor;
using UnityEngine;

namespace BrightLib.Scrubbing.Editor
{
    /// <summary>
    /// Fancy version of <see cref="ScrubberEditorWindow"/> with a sidebar
    /// </summary>
    public class FancyScrubberEditorWindow : ScrubberEditorWindow
    {
        private SerializedProperty _selectedProperty;
        private string _selectedPropertyPath;
        private Vector2 _leftContentScrollPosition;
        private Vector2 _rightContentScrollPosition;

        public override void OnGUI()
        {
            EditorGUILayout.BeginHorizontal();
            {
                _leftContentScrollPosition = EditorGUILayout.BeginScrollView(_leftContentScrollPosition);
                {
                    EditorGUILayout.BeginVertical("box", GUILayout.MaxWidth(150), GUILayout.ExpandHeight(true));
                    {
                        DrawSidebar();
                    }
                    EditorGUILayout.EndVertical();
                }
                EditorGUILayout.EndScrollView();

                _rightContentScrollPosition = EditorGUILayout.BeginScrollView(_rightContentScrollPosition);
                {
                    EditorGUILayout.BeginVertical("box", GUILayout.ExpandHeight(true));
                    {
                        if (_selectedProperty != null)
                        {
                            EditorGUILayout.BeginHorizontal("box");
                            {
                                EditorGUILayout.PropertyField(_selectedProperty, includeChildren: true);
                            }
                            EditorGUILayout.EndHorizontal();
                        }
                        else
                        {
                            EditorGUILayout.LabelField("Select an item from the list");
                        }
                    }
                    EditorGUILayout.EndVertical();
                }
                EditorGUILayout.EndScrollView();
            }
            EditorGUILayout.EndHorizontal();

            SerializedObject.ApplyModifiedProperties();
        }

        protected void DrawSidebar()
        {
            SerializedProperty prop = SerializedObject.GetIterator();
            if (prop.NextVisible(true))
            {
                do
                {
                    if (!string.Equals(prop.name, "m_Script"))
                    {
                        if (GUILayout.Button(prop.displayName))
                        {
                            _selectedPropertyPath = prop.propertyPath;
                        }
                    }
                }
                while (prop.NextVisible(false));
            }

            if (!string.IsNullOrEmpty(_selectedPropertyPath))
            {
                _selectedProperty = SerializedObject.FindProperty(_selectedPropertyPath);
            }
        }
    }
}