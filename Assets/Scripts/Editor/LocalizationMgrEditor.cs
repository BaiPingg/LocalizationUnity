using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine.UI;

namespace Localization
{
    [CustomEditor(typeof(LocalizationMgr))]
    public class LocalizationMgrEditor : Editor
    {
        LocalizationMgr mgr;

        string[] languages;
        private void Awake()
        {
            mgr = (LocalizationMgr)target;
            if (mgr.asset == null)
            {

                mgr.asset = Resources.Load<MyLocalizationAsset>("LocalizationAsset/LocalizationAsset");
            }

        }
        private void OnEnable()
        {

            languages = new string[mgr.asset.languageInfos.Length];
            for (int i = 0; i < languages.Length; i++)
            {
                languages[i] = mgr.asset.languageInfos[i].language.ToString();
            }
        }
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            mgr.choiceIndex = EditorGUILayout.Popup("Player", mgr.choiceIndex, languages);

            LocalizationMgr.Instance.CurrLanguage = LocalizationMgr.Instance.asset.languageInfos[mgr.choiceIndex].language;
            //SceneView.RepaintAll();
            //var objs = FindObjectsOfType<LocalizationText>();
            //for (int i = 0; i < objs.Length; i++)
            //{
             
            //    var str = LocalizationMgr.Instance.GetValue(objs[i].Key, LocalizationMgr.Instance.CurrLanguage);
            //    //Debug.LogError(str);
            //    objs[i].GetComponent<Text>().text = str;
            //}
        }
    }
}