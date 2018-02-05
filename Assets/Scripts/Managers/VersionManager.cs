/*
 * Title:  项目
 * 
 * Description: 功能
 * 
 * Author: 作者
 * 
 * Data: 日期
 */
using System.Collections;
using System.IO;
using System.Xml;
using UnityEngine;

public class VersionManager : MonoBehaviour
{
    string serverVersionURL;
    string localVersionPath;
    int localVersion;
    int serverVersion;

    private void Start()
    {
        localVersionPath = Application.dataPath + "/Packages/VersionData/version.xml";
        CheckVersion();
    }

    private int GetLocalVersion()
    {
        Debug.Log(localVersionPath);
        if (!File.Exists(localVersionPath))
        {
            XmlDocument doc = new XmlDocument();
            XmlElement version = doc.CreateElement("version");
            version.InnerText = "1";
            doc.AppendChild(version);
            doc.Save(localVersionPath);

            Debug.Log("created xmlVersion successfully!");
        }
        XmlDocument docRead = new XmlDocument();
        docRead.Load(localVersionPath);
        XmlElement versionRead = docRead.SelectSingleNode("version") as XmlElement;
        return int.Parse(versionRead.InnerText);
    }

    private void CheckVersion()
    {
        serverVersionURL = "http://.../UnityFiles/ProjectDemo/UnityAssetversion.xml";
        StartCoroutine(GetServerVersion(serverVersionURL));
    }

    private IEnumerator GetServerVersion(string url)
    {
        using (WWW www = new WWW(url))
        {
            yield return www;

            XmlDocument doc = new XmlDocument();
            doc.InnerXml = www.text;

            XmlElement version = doc.SelectSingleNode("version") as XmlElement;

            serverVersion = int.Parse(version.InnerText);

            localVersion = GetLocalVersion();
            if (localVersion < serverVersion)
            {
                Debug.Log("need update");

                //下载更新
                AssetBundleManager.Instance.LoadServerAssetBundle();

                //更新本地版本信息
                OverrideLocalVersion();
            }
            else
            {
                //本地加载
                AssetBundleManager.Instance.LoadLocalAssetBundle();
            }
        }
    }
    

    private void OverrideLocalVersion()
    {
        XmlDocument docWrite = new XmlDocument();
        docWrite.Load(localVersionPath);
        XmlElement versionWrite = docWrite.SelectSingleNode("version") as XmlElement;
        versionWrite.InnerText = serverVersion.ToString();
        docWrite.Save(localVersionPath);
    }
}