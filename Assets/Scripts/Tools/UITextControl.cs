using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class UITextControl : MonoBehaviour
{
    [SerializeField]
    private string key;
    // Use this for initialization
    void Start()
    {
        UITextChangeLanguage();
    }

    void UITextChangeLanguage()
    {
        key = this.gameObject.GetComponent<Text>().text;
        if (!string.IsNullOrEmpty(key))
        {
            string value = LanguageManager.Instance.GetText(key);
            if (!string.IsNullOrEmpty(value))
            {
                gameObject.GetComponent<Text>().text = Replace(value);
            }
        }
    }

    string Replace(string s)
    {
        return s.Replace("\\n", "\n");
    }
}