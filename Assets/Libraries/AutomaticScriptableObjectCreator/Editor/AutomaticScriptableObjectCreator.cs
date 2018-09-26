using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Assets.Libraries.AutomaticScriptableObjectCreator
{
    public class AutomaticScriptableObjectCreator : AssetPostprocessor
    {
        public static string path = "Assets/ScriptableObjects";

        [UnityEditor.Callbacks.DidReloadScripts]
        private static void OnScriptsReloaded()
        {
            string[] guids = AssetDatabase.FindAssets("*");
            for (int i = 0; i < guids.Length; i++)
            {
                string path = AssetDatabase.GUIDToAssetPath(guids[i]);
                TryCreateScriptableObject(path);
            }
        }

        private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            //foreach (string path in importedAssets)
            //    TryCreateScriptableObject(path);
        }

        private static void TryCreateScriptableObject(string path)
        {
            MonoScript script = AssetDatabase.LoadAssetAtPath<MonoScript>(path);

            if (script == null) return;

            var type = script.GetClass();

            if (type == null) return;
            if (!type.IsSubclassOf(typeof(ScriptableObject))) return;
            if (type.IsSubclassOf(typeof(Editor))) return;
            if (type.IsAbstract) return;
            if (AssetExists(type)) return;

            var destination = AutomaticScriptableObjectCreator.path;
            if (!Directory.Exists(destination))
                Directory.CreateDirectory(destination);

            var file = AssetDatabase.GenerateUniqueAssetPath(destination + "/" + type.Name + ".asset");

            var asset = ScriptableObject.CreateInstance(type);
            AssetDatabase.CreateAsset(asset, file);
            AssetDatabase.SaveAssets();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
        }

        private static bool AssetExists(Type type)
        {
            string[] guids = AssetDatabase.FindAssets("");
            for (int i = 0; i < guids.Length; i++)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(guids[i]);
                var asset = AssetDatabase.LoadAssetAtPath(assetPath, type);
                if (asset != null && asset.GetType() == type) return true;
            }
            return false;
        }
    }
}