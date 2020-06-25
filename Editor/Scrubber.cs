using BrightLib.Scrubbing.Runtime;
using System;
using UnityEditor;
using UnityEditor.Callbacks;
using Object = UnityEngine.Object;

namespace BrightLib.Scrubbing.Editor
{
    public sealed class Scrubber
    {
        public static void OpenScrubberEditorWindow(Object scrubData)
        {
            ScrubberEditorWindow wnd = EditorWindow.CreateWindow<ScrubberEditorWindow>(new Type[] { typeof(ScrubberEditorWindow) });
            wnd.titleContent = new UnityEngine.GUIContent(scrubData.name);
            wnd.SerializedObject = new SerializedObject(scrubData);
        }

        public static void OpenFancyScrubberEditorWindow(Object scrubData)
        {
            FancyScrubberEditorWindow wnd = EditorWindow.CreateWindow<FancyScrubberEditorWindow>(new Type[] { typeof(FancyScrubberEditorWindow) });
            wnd.titleContent = new UnityEngine.GUIContent(scrubData.name);
            wnd.SerializedObject = new SerializedObject(scrubData);
        }

        [OnOpenAsset()]
        public static bool HandleClickScrubData(int instanceId, int line)
        {
            Object obj = EditorUtility.InstanceIDToObject(instanceId) as Object;

            if (obj != null)
            {
                if (obj is IScrubData)
                {
                    OpenScrubberEditorWindow(obj);
                    return true;
                }
                else if (obj is IFancyScrubData)
                {
                    OpenFancyScrubberEditorWindow(obj);
                    return true;
                }
            }
            return false;
        }
    }
}