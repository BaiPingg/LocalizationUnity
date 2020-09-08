using System;
using UnityEngine;
using Localization;

public class LocalizationMgr : MonoBehaviour
{
    public MyLocalizationAsset asset;
    static LocalizationMgr instance;
    public Action<SystemLanguage> OnLanguageChanged;
    private SystemLanguage currLanguage;

    public SystemLanguage CurrLanguage
    {
        get
        {
            return currLanguage;
        }
        set
        {
            currLanguage = value;
            if (OnLanguageChanged != null)
            {
                OnLanguageChanged(currLanguage);
            }
          
        }
    }

    public static LocalizationMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(LocalizationMgr)) as LocalizationMgr;
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = "[LocalizationMgr]";
                    instance = obj.AddComponent<LocalizationMgr>();
                }
            }
            return instance;
        }

    }
    private void Awake()
    {
        if (asset == null)
        {
            Debug.LogError("LocalizationAsset is  null, please check asset");
        }
    }

    public string GetValue (string key ,SystemLanguage lang)
    { var haskey = false;
        int keyindex=0, langindex =0;
        var haslanguage = false;
        if (asset == null)
        {
            Debug.LogError("LocalizationAsset is  null, please check asset");
            return "";
        }

        for (int i = 0; i < asset.keys.Length; i++)
        {
            if (asset.keys[i] == key)
            {
                haskey = true;
                keyindex = i;
            }
        }
        if (haskey == false)
        {
            Debug.LogError("Not contains thy key:" + key);
            return "";
        }

        for (int i = 0; i < asset.languageInfos.Length; i++)
        {
            if (asset.languageInfos[i].language == lang)
            {
                haslanguage = true;
                langindex = i;
            }
        }
        if (haslanguage == false)
        {
            Debug.LogError("Not contains thy language:" + lang);
            return "";
        }
        if (haslanguage ==true && haskey == true)
        {
            return asset.languageInfos[langindex].stringInfo[keyindex].value;
        }
        return "";

    }

}
