﻿using BrightLib.Scrubbing.Runtime;
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
		/// The root path for scrubber menu items.
		/// </summary>
		private const string MENU_ITEM_PATH = "Assets/Scrubber/";

        /// <summary>
        /// Menu items priority (so they will be grouped/shown next to existing scripting menu items).
        /// </summary>
        private const int MENU_ITEM_PRIORITY = 70;

        /// <summary>
		/// Open ScriptableObject with ScrubberWindow
		/// </summary>
		[MenuItem(MENU_ITEM_PATH + "Open with Scrubber Window", false, MENU_ITEM_PRIORITY)]
        private static void OpenWithScrubberWindow()
        {
            var selectedObject = Selection.activeObject;
            if (selectedObject is ScriptableObject)
            {
                OpenScrubberEditorWindow<ScrubberEditorWindow>(selectedObject);
            }
        }

        /// <summary>
		/// Open ScriptableObject with FancyScrubberWindow
		/// </summary>
		[MenuItem(MENU_ITEM_PATH + "Open with Fancy Scrubber Window", false, MENU_ITEM_PRIORITY)]
        private static void OpenWithFancyScrubberWindow()
        {
            var selectedObject = Selection.activeObject;
            if (selectedObject is ScriptableObject)
            {
                OpenScrubberEditorWindow<FancyScrubberEditorWindow>(selectedObject);
            }
        }

        public static void OpenScrubberEditorWindow(Object scrubData)
        {
            OpenScrubberEditorWindow<ScrubberEditorWindow>(scrubData);
        }

        public static void OpenFancyScrubberEditorWindow(Object scrubData) 
        {
            OpenScrubberEditorWindow<FancyScrubberEditorWindow>(scrubData);
        }

        private static void OpenScrubberEditorWindow<T>(Object scrubData) where T : ScrubberEditorWindow
        {
            T window = EditorWindow.CreateWindow<T>(new Type[] { typeof(T) });
            window.titleContent = new UnityEngine.GUIContent(scrubData.name);
            window.SerializedObject = new SerializedObject(scrubData);
        }

        [OnOpenAsset]
        public static bool HandleClickScrubData(int instanceId, int line)
        {
            Object obj = EditorUtility.InstanceIDToObject(instanceId) as Object;

            if (obj == null)
            {
                return false;
            }

            if (Attribute.IsDefined(obj.GetType(), typeof(ScrubDataAttribute)))
            {
                OpenScrubberEditorWindow<ScrubberEditorWindow>(obj);
                return true;
            }
            else if (Attribute.IsDefined(obj.GetType(), typeof(FancyScrubDataAttribute)))
            {
                OpenScrubberEditorWindow<FancyScrubberEditorWindow>(obj);
                return true;
            }
            return false;
        }
    }
}