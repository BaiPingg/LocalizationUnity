using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace Localization
{
    [CustomEditor(typeof(MyLocalizationAsset))]
    public class LocalizationEditor : Editor
    {
        MyLocalizationAsset asset;
        private void Awake()
        {
            asset = (MyLocalizationAsset)target;
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