using System.Collections.Generic;
using UnityEngine;
using Yishimu;
public class LanguageManager : SingleTonMono<LanguageManager>
{
    [SerializeField]
    private SystemLanguage language;

    private Dictionary<string, string> dict = new Dictionary<string, string>();

    void Awake()
    {
        loadLanguage(language.ToString());
        //Canvas.BroadcastMessage("UITextChangeLanguage");
        //Canvas.BroadcastMessage("UIImageChangeLanguage");
    }

    /// <summary>
    /// 加载预翻译的语言
    /// </summary>
    private void loadLanguage(string language)
    {
        //加载文件
        TextAsset ta = Resources.Load<TextAsset>("Language/" + language);
        if (ta == null)
        {
            Debug.LogWarning("没有这个语言的翻译文件");
            return;
        }
        //获取每一行
        string[] lines = ta.text.Split('\n');
        //获取key value
        for (int i = 0; i < lines.Length; i++)
        {
            //检测
            if (string.IsNullOrEmpty(lines[i]) || string.Equals(lines[i], "\r"))
            {
                continue;
            }
            //获取 key:kv[0] value kv[1]
            string[] kv = lines[i].Split(':');
            //保存到字典
            if (!dict.ContainsKey(kv[0]))
            {
                dict.Add(kv[0], kv[1]);
            }
        }
    }

    /// <summary>
    /// 获取对应的value
    /// </summary>
    /// <param name="key">键</param>
    /// <returns>返回对应的value 如果不存在返回空串</returns>
    public string GetText(string key)
    {
        if (dict.ContainsKey(key))
        {
            return dict[key];
        }
        else//没有这个key
        {
            return string.Empty;
        }
    }
}