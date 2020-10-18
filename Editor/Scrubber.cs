using BrightLib.Scrubbing.Runtime;
using System;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BrightLib.Scrubbing.Editor
{
    public sealed class Scrubber
    {
        /// <summary>
		/// The root path for code templates menu items.
		/// </summary>
		private const string MENU_ITEM_PATH = "Assets/Scrubber/";

        /// <summary>
        /// Menu items priority (so they will be grouped/shown next to existing scripting menu items).
        /// </summary>
        private const int MENU_ITEM_PRIORITY = 70;

        /// <summary>
		/// Creates a new C# class.
		/// </summary>
		[MenuItem(MENU_ITEM_PATH + "Open with Scrubber Window", false, MENU_ITEM_PRIORITY)]
        private static void OpenWithScrubber()
        {
            var selectedObject = Selection.activeObject;
            if (selectedObject is ScriptableObject)
            {
                OpenScrubberEditorWindow(selectedObject);
            }
        }

        /// <summary>
		/// Creates a new C# class.
		/// </summary>
		[MenuItem(MENU_ITEM_PATH + "Open with Fancy Scrubber Window", false, MENU_ITEM_PRIORITY)]
        private static void OpenWithFancyScrubber()
        {
            var selectedObject = Selection.activeObject;
            if (selectedObject is ScriptableObject)
            {
                OpenFancyScrubberEditorWindow(selectedObject);
            }
        }

        //private static void OpenScrubberEditorWindow<T>(Object scrubData) where T : ScrubberEditorWindow
        //{
        //    T wnd = EditorWindow.CreateWindow<T>(new Type[] { typeof(T) });
        //    wnd.titleContent = new UnityEngine.GUIContent(scrubData.name);
        //    wnd.SerializedObject = new SerializedObject(scrubData);
        //}

        private static void OpenScrubberEditorWindow(Object scrubData)
        {
            ScrubberEditorWindow wnd = EditorWindow.CreateWindow<ScrubberEditorWindow>(new Type[] { typeof(ScrubberEditorWindow) });
            wnd.titleContent = new UnityEngine.GUIContent(scrubData.name);
            wnd.SerializedObject = new SerializedObject(scrubData);
        }

        private static void OpenFancyScrubberEditorWindow(Object scrubData)
        {
            FancyScrubberEditorWindow wnd = EditorWindow.CreateWindow<FancyScrubberEditorWindow>(new Type[] { typeof(FancyScrubberEditorWindow) });
            wnd.titleContent = new UnityEngine.GUIContent(scrubData.name);
            wnd.SerializedObject = new SerializedObject(scrubData);
        }

        [OnOpenAsset()]
        public static bool HandleClickScrubData(int instanceId, int line)
        {
            Object obj = EditorUtility.InstanceIDToObject(instanceId) as Object;

            if (obj == null)
            {
                return false;
            }

            if (Attribute.IsDefined(obj.GetType(), typeof(ScrubDataAttribute)))
            {
                OpenScrubberEditorWindow(obj);
                return true;
            }
            else if (Attribute.IsDefined(obj.GetType(), typeof(FancyScrubDataAttribute)))
            {
                OpenFancyScrubberEditorWindow(obj);
                return true;
            }
            return false;
        }
    }
}