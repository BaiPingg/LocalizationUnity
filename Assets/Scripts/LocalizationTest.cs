using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Localization;
using UnityEngine.UI;


public class LocalizationTest : MonoBehaviour
{
    public MyLocalizationAsset asset;
    public Text text;
    public SystemLanguage currLanguage;
    private void Start()
    {
        
            for (int i = 0; i < asset.languageInfos.Length; i++)
            {
                if (currLanguage == asset.languageInfos[i].language)
                {
                Generate(asset.languageInfos[i].stringInfo);
                }
            }
        
    }

    public void  Generate(StringKeyValue[] info)
    {
        for (int i = 0; i < info.Length; i++)
        {
            var _text = GameObject.Instantiate(text, text.transform.parent);
            _text.text = info[i].key + " : " + info[i].value;
            _text.gameObject.SetActive(true);
        }
    }
}
