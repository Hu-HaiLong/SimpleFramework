using System.Collections;
using Yishimu;
using UnityEngine;

public class NetWorkManager : SingleTonMono<NetWorkManager>
{

    private void Awake()
    {

        //SocketHelper.Instance.SendMessage("I am client");
        StartCoroutine(test(URL_DEFINE.URL + URL_DEFINE.STRING_CONTENT_SERVLET));
    }

    //访问JSP服务器
    IEnumerator test(string path)
    {
        WWW www = new WWW(path);
        yield return www;
        //如果发生错误，打印
        if (www.error != null)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.text);
        }
        www.Dispose(); //释放资源
    }
}
