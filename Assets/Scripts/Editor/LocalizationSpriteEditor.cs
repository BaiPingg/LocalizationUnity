using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

namespace Localization
{
[CustomEditor(typeof(LocalizationSprite))]
public class LocalizationSpriteEditor : Editor
    {
        LocalizationSprite asset;
        List<string> strs = new List<string>();

        private void Awake()
        {

            asset = (LocalizationSprite)target;

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

            asset.GetComponent<SpriteRenderer>().sprite = LocalizationMgr.Instance.GetValue(asset.Key, LocalizationMgr.Instance.CurrLanguage).sprite;
            EditorUtility.SetDirty(asset);
        }

    }
}