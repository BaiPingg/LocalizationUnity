using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LocalizationText : MonoBehaviour
{
    private Text text;
    public string key;
    private string vale;

    private void Start()
    {
        if (string.IsNullOrEmpty(key))
        {
            
            Debug.LogError("key is null");
        }
        vale = LocalizationMgr.Instance.GetValue(key, LocalizationMgr.Instance.CurrLanguage);
    }
}
