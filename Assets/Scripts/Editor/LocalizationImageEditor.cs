using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

namespace Localization
{
    [CustomEditor(typeof(LocalizationImage))]
    public class LocalizationImageEditor : Editor
    {
        LocalizationImage asset;
        List<string> strs = new List<string>();

        private void Awake()
        {

            asset = (LocalizationImage)target;

            for (int i = 0; i < LocalizationMgr.Instance.asset.localizationAssetKeys.Length; i++)
            {
                if (LocalizationMgr.Instance.asset.localizationAssetKeys[i].localizationType == LocalizationAssetType.sprite)
                {
                    strs.Add(LocalizationMgr.Instance.asset.localizationAssetKeys[i].key);
                }


            }

        }
        public override void OnInspectorGUI()
        {

            DrawDefaultInspector();


            asset.choiceIndex = EditorGUILayout.Popup("Key", asset.choiceIndex, strs.ToArray());
            asset.SetKey(strs[asset.choiceIndex]);

            asset.GetComponent<Image>().sprite = LocalizationMgr.Instance.GetValue(asset.Key, LocalizationMgr.Instance.CurrLanguage).sprite;
            EditorUtility.SetDirty(asset);
        }

    }
}