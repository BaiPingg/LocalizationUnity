using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Localization
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class LocalizationSprite : MonoBehaviour
    {
        private SpriteRenderer render;
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
                render = GetComponent<SpriteRenderer>();

                render.sprite = LocalizationMgr.Instance.GetValue(Key, LocalizationMgr.Instance.CurrLanguage).sprite;
            }
        }



        private void Start()
        {
            render = GetComponent<SpriteRenderer>();
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
          
            render = GetComponent<SpriteRenderer>();
            render.sprite = LocalizationMgr.Instance.GetValue(Key, LocalizationMgr.Instance.CurrLanguage).sprite;
        }


    }
}