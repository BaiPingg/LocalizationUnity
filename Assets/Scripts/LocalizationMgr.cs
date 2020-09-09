using System;
using UnityEngine;
using Localization;
using System.Reflection;

public class LocalizationMgr : MonoBehaviour
{
    public string saveKey = "localizationlanguage"; 
    public MyLocalizationAsset asset;
    static LocalizationMgr instance;
    public Action<SystemLanguage> OnLanguageChanged;
    [HideInInspector]
    public int choiceIndex = 0;
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
                    DontDestroyOnLoad(obj);
                }
            }
            return instance;
        }

    }
    private void Awake()
    {
        if (asset == null)
        {
            //Debug.LogError("LocalizationAsset is  null, please check asset");
            asset = Resources.Load<MyLocalizationAsset>("LocalizationAsset/LocalizationAsset");
          
        }
        InitLanguage();
    }

    public LocalizationAssetValue GetValue (string key ,SystemLanguage lang)
    { var haskey = false;
        int keyindex=0, langindex =0;
        var haslanguage = false;
        if (asset == null)
        {
            Debug.LogError("LocalizationAsset is  null, please check asset");
            return null;
        }

        for (int i = 0; i < asset.localizationAssetKeys.Length; i++)
        {
            if (asset.localizationAssetKeys[i].key == key)
            {
                haskey = true;
                keyindex = i;
            }
        }
        if (haskey == false)
        {
            Debug.LogError("Not contains thy key:" + key);
            return null;
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
          
            return null;
        }
        if (haslanguage ==true && haskey == true)
        {
            return asset.languageInfos[langindex].localizationAssetValues[keyindex];
        }
        return null;

    }

    public int GetCurrentLanguageIndex()
    {
        for (int i = 0; i < asset.languageInfos.Length; i++)
        {
            if (asset.languageInfos[i].language ==currLanguage)
            {
                return i;
            }
        }
        return 0;
    }


   public void InitLanguage()
    {
      
        SystemLanguage lang = String2Language(PlayerPrefs.GetString(saveKey));
        currLanguage = lang;
        
    }

    public static SystemLanguage String2Language(string str)
    {
        FieldInfo[] fields = typeof(SystemLanguage).GetFields();
        for (int i = 0; i < fields.Length; i++)
        {
            if (i > 0)
            {
               
                var index = (int)fields[i].GetValue(null);
                if (str == ((SystemLanguage)index).ToString())
                {
                    return (SystemLanguage)index;
                }
            }
           
        }
        return SystemLanguage.English;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString(saveKey, currLanguage.ToString());
    }
}
