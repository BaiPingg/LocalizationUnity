using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Localization;
using UnityEngine.UI;


public class LocalizationTest : MonoBehaviour
{
    public Dropdown dropdown;

    private void Start()
    {
        dropdown.ClearOptions();
        List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();


        for (int i = 0; i < LocalizationMgr.Instance.asset.languageInfos.Length; i++)
        {
            var op = new Dropdown.OptionData();
            op.text = LocalizationMgr.Instance.asset.languageInfos[i].language.ToString();
            options.Add(op);
        }
        dropdown.AddOptions(options);
        dropdown.onValueChanged.AddListener(ChangeValue);
        dropdown.value = LocalizationMgr.Instance.GetCurrentLanguageIndex();
    }

    void ChangeValue(int index)
    {
        LocalizationMgr.Instance.CurrLanguage = LocalizationMgr.Instance.asset.languageInfos[index].language;
    }
}
