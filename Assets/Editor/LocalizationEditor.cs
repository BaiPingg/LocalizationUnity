using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace Localization
{
    [CustomEditor(typeof(LocalizationAsset))]
    public class LocalizationEditor : Editor
    {
        LocalizationAsset asset;
        private void Awake()
        {
            asset = (LocalizationAsset)target;
        }

        public override void OnInspectorGUI()
        {

            if (GUILayout.Button("Open in editor"))
            {
                LocalizationEditorWindow.Init(asset);

            }

        }

    }
}