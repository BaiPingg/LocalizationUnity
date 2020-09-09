using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace Localization
{
    public class LocalizationEditorWindow : EditorWindow
    {

        public static MyLocalizationAsset asset;

        private Vector2 scrollPos;
        public static void Init(MyLocalizationAsset obj)
        {
            asset = obj;


            EditorWindow window = GetWindow<LocalizationEditorWindow>(false, "localizationEditor");
            window.Show();
        }
        void OnGUI()
        {


            if (GUILayout.Button("+", GUILayout.MaxWidth(100)))
            {
                var info = new LanguageInfo();
                info.localizationAssetValues = new LocalizationAssetValue[asset.localizationAssetKeys.Length];
                for (int i = 0; i < info.localizationAssetValues.Length; i++)
                {
                    info.localizationAssetValues[i] = new LocalizationAssetValue();
                    info.localizationAssetValues[i].text = "";
                    info.localizationAssetValues[i].sprite = null;
                    info.localizationAssetValues[i].audioClip = null;
                }
                asset.languageInfos = AddElement<LanguageInfo>(asset.languageInfos, info);

            }
            EditorGUILayout.BeginScrollView(scrollPos);
            EditorGUILayout.BeginHorizontal("box");

            EditorGUILayout.BeginVertical("box", GUILayout.MaxWidth(300));
            EditorGUILayout.LabelField("Keys");
            for (int i = 0; i < asset.localizationAssetKeys.Length; i++)
            {
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button("-", GUILayout.MaxWidth(50)))
                {
                    asset.localizationAssetKeys = RemoveElement(asset.localizationAssetKeys, asset.localizationAssetKeys[i]);
                    for (int k = 0; k < asset.languageInfos.Length; k++)
                    {
                        asset.languageInfos[k].localizationAssetValues = RemoveElement(asset.languageInfos[k].localizationAssetValues, asset.languageInfos[k].localizationAssetValues[i]);
                    }
                }
                else
                {
                    asset.localizationAssetKeys[i].key = EditorGUILayout.TextField(asset.localizationAssetKeys[i].key, GUILayout.Height(25));
                    asset.localizationAssetKeys[i].localizationType =
                        (LocalizationAssetType)EditorGUILayout.EnumPopup(asset.localizationAssetKeys[i].localizationType, GUILayout.MaxWidth(200));
                  
                }


                EditorGUILayout.EndHorizontal();
            }
            if (GUILayout.Button("+", GUILayout.MaxWidth(100)))
            {
                asset.localizationAssetKeys = AddElement(asset.localizationAssetKeys, new LocalizationAssetKey());
                for (int i = 0; i < asset.languageInfos.Length; i++)
                {
                    asset.languageInfos[i].localizationAssetValues = AddElement(asset.languageInfos[i].localizationAssetValues, new LocalizationAssetValue( ));
                }
            }

            EditorGUILayout.EndVertical();

            for (int j = 0; j < asset.languageInfos.Length; j++)
            {
                #region MyRegion

                EditorGUILayout.BeginVertical("box", GUILayout.MaxWidth(300));

                #region MyRegion


                EditorGUILayout.BeginHorizontal();
                asset.languageInfos[j].language = (SystemLanguage)EditorGUILayout.EnumPopup("Language:", asset.languageInfos[j].language, GUILayout.MaxWidth(200));


                if (GUILayout.Button("-", GUILayout.MaxWidth(50)))
                {
                    asset.languageInfos = RemoveElement(asset.languageInfos, asset.languageInfos[j]);

                }
                else
                {
                    EditorGUILayout.EndHorizontal();
                    for (int i = 0; i < asset.localizationAssetKeys.Length; i++)
                    {
                        switch (asset.localizationAssetKeys[i].localizationType)
                        {
                            case LocalizationAssetType.text:

                                asset.languageInfos[j].localizationAssetValues[i].text = EditorGUILayout.TextField(asset.languageInfos[j].localizationAssetValues[i].text, GUILayout.Height(25));

                                break;
                            case LocalizationAssetType.sprite:

                                asset.languageInfos[j].localizationAssetValues[i].sprite = (Sprite)EditorGUILayout.ObjectField(asset.languageInfos[j].localizationAssetValues[i].sprite, typeof(Sprite), GUILayout.Height(25));

                                break;
                            case LocalizationAssetType.audio:

                                asset.languageInfos[j].localizationAssetValues[i].audioClip = (AudioClip)EditorGUILayout.ObjectField(asset.languageInfos[j].localizationAssetValues[i].audioClip, typeof(AudioClip), GUILayout.Height(25));

                                break;

                        }


                        #endregion

                    }
                  
                    EditorGUILayout.EndVertical();
                    #endregion
                }

            }


            EditorGUILayout.EndHorizontal();

            EditorGUILayout.EndScrollView();


            //重新绘制window
            this.Repaint();
            EditorUtility.SetDirty(asset);
        }

        void OnDestroy()
        {
            //将编辑的资源保存
            EditorUtility.SetDirty(asset);


        }
        void OnLostFocus()
        {
            EditorUtility.SetDirty(asset);
        }

        public T[] RemoveElement<T>(T[] elements, T element)
        {
            List<T> elementsList = new List<T>(elements);
            elementsList.Remove(element);
            return elementsList.ToArray();
        }


        public T[] CopyElement<T>(T[] elements)
        {
            List<T> elementsList = new List<T>(elements);

            return elementsList.ToArray();
        }

        public T[] AddElement<T>(T[] elements, T element)
        {
            List<T> elementsList = new List<T>(elements);
            elementsList.Add(element);
            return elementsList.ToArray();
        }


    }
}