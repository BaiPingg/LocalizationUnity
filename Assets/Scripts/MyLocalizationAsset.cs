using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Localization
{
    [CreateAssetMenu(fileName = "LocalizationAsset", menuName = "Localization/LocalizationAsset")]
    public class MyLocalizationAsset : ScriptableObject
    {
        public LanguageInfo[] languageInfos = new LanguageInfo[0];
        public string[] keys = new string[0];
    }

    [System.Serializable]
    public class LanguageInfo
    {
        [SerializeField]
        public SystemLanguage language;
        [SerializeField]
        public StringKeyValue[] stringInfo = new StringKeyValue[0];

 
        public LanguageInfo()
        {

        }

        public StringKeyValue GetElement(string key)
        {
            for (int i = 0; i < stringInfo.Length; i++)
            {
                if (stringInfo[i].key == key)
                {
                    return stringInfo[i];
                }
            }
            Debug.LogError("Cant Find the key:" + key);
            return new StringKeyValue();
        }

        public string GetValue(string key)
        {
            for (int i = 0; i < stringInfo.Length; i++)
            {
                if (stringInfo[i].key == key)
                {
                    return stringInfo[i].value;
                }
            }
            Debug.LogError("Cant Find the key:" + key);
            return "";
        }

        public string GetKey(string value)
        {
            for (int i = 0; i < stringInfo.Length; i++)
            {
                if (stringInfo[i].value == value)
                {
                    return stringInfo[i].key;
                }
            }
            Debug.LogError("Cant Find the value:" + value);
            return "";
        }


    }
    [System.Serializable]
    public struct StringKeyValue
    {
        [SerializeField]
        public string key;
        [SerializeField]
        public string value;

        public StringKeyValue(string key1 ,string value1)
        {
            key = key1;
            value = value1;

        }

    }
}