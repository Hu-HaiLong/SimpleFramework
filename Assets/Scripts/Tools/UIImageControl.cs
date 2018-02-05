using UnityEngine;
using UnityEngine.UI;

public class UIImageControl : MonoBehaviour {

    string path= "Textures/UIImage/";
    [SerializeField]
    private string key;
    // Use this for initialization
    void OnEnable()
    {
        UIImageChangeLanguage();
    }

    void UIImageChangeLanguage()
    {
        key = this.gameObject.name;
        if (!string.IsNullOrEmpty(key))
        {
            string value = LanguageManager.Instance.GetText(key);
            value = Replace(value);
            if (!string.IsNullOrEmpty(value))
            {
                gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(path+value) ;
            }
        }
    }

    string Replace(string s)
    {
        return s.Replace("\r", "");
    }
}
