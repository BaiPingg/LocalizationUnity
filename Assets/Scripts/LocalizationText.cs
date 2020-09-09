using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Localization
{
    [RequireComponent(typeof(Text))]
    public class LocalizationText : MonoBehaviour
    {
        private Text text;
        [SerializeField]
        private string key;
        [HideInInspector]
       public int choiceIndex  =0;
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
                text = GetComponent<Text>();
                text.text = LocalizationMgr.Instance.GetValue(Key, LocalizationMgr.Instance.CurrLanguage);
            }
        }
        private void Start()
        {
            text = GetComponent<Text>();
            if (string.IsNullOrEmpty(key))
            {

                Debug.LogError("key is null");
                return;
            }

            text.text = LocalizationMgr.Instance.GetValue(Key, LocalizationMgr.Instance.CurrLanguage);
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
            //Debug.LogError(lang);
            text = GetComponent<Text>();
            text.text = LocalizationMgr.Instance.GetValue(Key, LocalizationMgr.Instance.CurrLanguage);
            //Debug.LogError(text.text);
            //Debug.LogError(LocalizationMgr.Instance.CurrLanguage);
        }



        #region Test
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Key = "exit";
            }
        }
        #endregion
    }
}