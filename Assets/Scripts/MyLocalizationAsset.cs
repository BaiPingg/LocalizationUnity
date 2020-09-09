using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Localization
{
    [CreateAssetMenu(fileName = "LocalizationAsset", menuName = "Localization/LocalizationAsset")]
    public class MyLocalizationAsset : ScriptableObject
    {
        public LanguageInfo[] languageInfos = new LanguageInfo[0];
        public LocalizationAssetKey[] localizationAssetKeys = new LocalizationAssetKey[0];
    }

    public enum LocalizationAssetType
    {
        text,sprite,audio
    }

    [System.Serializable]
    public class LocalizationAssetKey
    {
        public string key;
        public LocalizationAssetType localizationType;
    }


    [System.Serializable]
    public class LanguageInfo
    {
        [SerializeField]
        public SystemLanguage language;
        [SerializeField]
        public LocalizationAssetValue[] localizationAssetValues = new LocalizationAssetValue[0];


     
    }
    [System.Serializable]
    public class LocalizationAssetValue
    {
    
        [SerializeField]
        public string text;
        [SerializeField]
        public Sprite sprite;
        [SerializeField]
        public AudioClip audioClip;

    }
}