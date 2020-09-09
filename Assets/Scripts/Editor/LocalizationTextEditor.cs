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
        List<string> strs = new List<string>();

        private void Awake()
        {

            asset = (LocalizationText)target;
            
            for (int i = 0; i < LocalizationMgr.Instance.asset.localizationAssetKeys.Length; i++)
            {
                if (LocalizationMgr.Instance.asset.localizationAssetKeys[i].localizationType == LocalizationAssetType.text)
                {
                    strs.Add(LocalizationMgr.Instance.asset.localizationAssetKeys[i].key);
                }
               
              
            }

        }
        public override void OnInspectorGUI()
        {
           
            DrawDefaultInspector();


            asset.choiceIndex = EditorGUILayout.Popup("Key", asset.choiceIndex, strs.ToArray());
            asset.SetKey (strs[asset.choiceIndex]);

            asset.GetComponent<Text>().text = LocalizationMgr.Instance.GetValue(asset.Key,LocalizationMgr.Instance.CurrLanguage).text;
            EditorUtility.SetDirty(asset);
        }


     
    }
}