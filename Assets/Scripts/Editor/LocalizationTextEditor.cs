using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

namespace Localization
{
    [CustomEditor(typeof(LocalizationText))]
    public class LocalizationTextEditor : Editor
    {
        LocalizationText asset;

        private void Awake()
        {

            asset = (LocalizationText)target;

        }
        public override void OnInspectorGUI()
        {
           
            DrawDefaultInspector();


            asset.choiceIndex = EditorGUILayout.Popup("Player", asset.choiceIndex, LocalizationMgr.Instance.asset.keys);
            asset.SetKey (LocalizationMgr.Instance.asset.keys[asset.choiceIndex]);

            asset.GetComponent<Text>().text = LocalizationMgr.Instance.GetValue(asset.Key,LocalizationMgr.Instance.CurrLanguage);
            EditorUtility.SetDirty(asset);
        }


     
    }
}