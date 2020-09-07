using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace Localization
{
    public class LocalizationEditorWindow : EditorWindow
    {

        public static LocalizationAsset asset;

        private Vector2 scrollPos;
        public static void Init(LocalizationAsset obj)
        {
            asset = obj;


            EditorWindow window = GetWindow<LocalizationEditorWindow>(false, "localizationEditor");
            window.Show();
        }
        void OnGUI()
        {
            EditorGUILayout.BeginScrollView(scrollPos);
            EditorGUILayout.BeginVertical();

            EditorGUILayout.Space();
            EditorGUILayout.BeginHorizontal(GUILayout.MinHeight(100));

            
            for (int i = 0; i < asset.languageInfos.Length; i++)
            {
                asset.languageInfos[i].language = (SystemLanguage)EditorGUILayout.EnumPopup("Language:", asset.languageInfos[i].language, GUILayout.MaxWidth(300));


                if (GUILayout.Button("-", GUILayout.MaxWidth(50)))
                {
                    asset.languageInfos = RemoveElement<LanguageInfo>(asset.languageInfos, asset.languageInfos[i]);
                }
            }
            if (GUILayout.Button("+", GUILayout.MaxWidth(50)))
            {
                asset.languageInfos = AddElement<LanguageInfo>(asset.languageInfos, new LanguageInfo());
            }
            EditorGUILayout.EndHorizontal();

            if (asset.languageInfos.Length>=0)
            {

                GUILayout.Box("sss", GUILayout.Width(200), GUILayout.Height(0500));
                //for (int i = 0; i < max; i++)
                //{

                //}
            }
            
            EditorGUILayout.EndVertical();
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