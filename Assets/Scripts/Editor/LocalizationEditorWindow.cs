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
                info.stringInfo = new StringKeyValue[asset.keys.Length];
                for (int i = 0; i < info.stringInfo.Length; i++)
                {
                    info.stringInfo[i].key = asset.keys[i];
                    info.stringInfo[i].value = "";
                }
                asset.languageInfos = AddElement<LanguageInfo>(asset.languageInfos,info);
                
            }
            EditorGUILayout.BeginScrollView(scrollPos);
            EditorGUILayout.BeginHorizontal("box");

            EditorGUILayout.BeginVertical("box",GUILayout.MaxWidth(300));
            EditorGUILayout.LabelField("Keys");
            for (int i = 0; i < asset.keys.Length; i++)
            {
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button("-", GUILayout.MaxWidth(50)))
                {
                    asset.keys = RemoveElement<string>(asset.keys, asset.keys[i]);
                    for (int k = 0; k < asset.languageInfos.Length; k++)
                    {
                        asset.languageInfos[k].stringInfo = RemoveElement<StringKeyValue>(asset.languageInfos[k].stringInfo, asset.languageInfos[k].stringInfo[i]);
                    }
                }
                else
                {
                    asset.keys[i] = EditorGUILayout.TextField(asset.keys[i], GUILayout.Height(25));
                    //for (int m = 0; i < asset.languageInfos.Length; m++)
                    //{
                        
                    //        asset.languageInfos[m].stringInfo[i].key = asset.keys[i];
                       
                       
                    //}
                }
               
               
                EditorGUILayout.EndHorizontal();
            }
            if (GUILayout.Button("+", GUILayout.MaxWidth(100)))
            {
                asset.keys = AddElement<string>(asset.keys, "");
                for (int i = 0; i < asset.languageInfos.Length; i++)
                {
                    asset.languageInfos[i].stringInfo = AddElement<StringKeyValue>(asset.languageInfos[i].stringInfo, new StringKeyValue("", ""));
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
                    asset.languageInfos = RemoveElement<LanguageInfo>(asset.languageInfos, asset.languageInfos[j]);
                   
                }
                else
                {
                    EditorGUILayout.EndHorizontal();
                    #endregion
                    for (int i = 0; i < asset.languageInfos[j].stringInfo.Length; i++)
                    {
                        asset.languageInfos[j].stringInfo[i].value = EditorGUILayout.TextField(asset.languageInfos[j].stringInfo[i].value, GUILayout.Height(25));
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