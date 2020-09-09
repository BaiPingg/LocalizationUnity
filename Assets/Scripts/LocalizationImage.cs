using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Localization
{
        [RequireComponent(typeof(Image))]
    public class LocalizationImage : MonoBehaviour
    {

        private Image render;
        [SerializeField]
        private string key;
        [HideInInspector]
        public int choiceIndex = 0;
        public void SetKey(string key)
        {
            this.key = key;
        }
        public string Key
        {
            get { return key; }
            set
            {
                key = value;
                render = GetComponent<Image>();

                render.sprite = LocalizationMgr.Instance.GetValue(Key, LocalizationMgr.Instance.CurrLanguage).sprite;
            }
        }



        private void Start()
        {
            render = GetComponent<Image>();
            if (string.IsNullOrEmpty(key))
            {

                Debug.LogError("key is null");
                return;
            }

            render.sprite = LocalizationMgr.Instance.GetValue(Key, LocalizationMgr.Instance.CurrLanguage).sprite;
        }

        private void OnEnable()
        {

            LocalizationMgr.Instance.OnLanguageChanged += ChangeLanguage;
        }
        private void OnDisable()
        {
            LocalizationMgr.Instance.OnLanguageChanged -= ChangeLanguage;

        }

        public void ChangeLanguage(SystemLanguage lang)
        {

            render = GetComponent<Image>();
            render.sprite = LocalizationMgr.Instance.GetValue(Key, LocalizationMgr.Instance.CurrLanguage).sprite;
        }

    }
}