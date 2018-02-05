using System;
using Yishimu;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SignTimeManager : SingleTonMono<SignTimeManager> {

    [HideInInspector]
    public string timeNow;

	// Use this for initialization
	void Start () {
        StartCoroutine(TodayData());
	}
	


    /// <summary>
    /// 获取当前服务器时间
    /// </summary>
    /// <returns></returns>
    IEnumerator TodayData()
    {
        if ( IsNetConnect() > 0)
        {
            //获取服务器当前时间
            string str = GetWebClient("http://www.hko.gov.hk/cgi-bin/gts/time5a.pr?a=2");
            string timeStamp = str.Split('=')[1].Substring(0, 10);
            DateTime datetimeNet = GetTime(timeStamp);
            timeNow = datetimeNet.Year.ToString() + datetimeNet.Month.ToString() + datetimeNet.Day.ToString();
            yield return timeNow;
        }
        //return null;
    }

    private static string GetWebClient(string url)
    {
        string strHTML = "";
        WebClient myWebClient = new WebClient();
        Stream myStream = myWebClient.OpenRead(url);
        StreamReader sr = new StreamReader(myStream, System.Text.Encoding.GetEncoding("utf-8"));
        strHTML = sr.ReadToEnd();
        myStream.Close();
        return strHTML;
    }

    /// <summary>
    /// 时间戳转为C#格式时间
    /// </summary>
    /// <param name="timeStamp">Unix时间戳格式</param>
    /// <returns>C#格式时间</returns>
    public static DateTime GetTime(string timeStamp)
    {
        DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        long lTime = long.Parse(timeStamp + "0000000");
        TimeSpan toNow = new TimeSpan(lTime);
        return dtStart.Add(toNow);
    }


    /// <summary>
    /// 是否联网
    /// </summary>
    /// <returns></returns>
    public int IsNetConnect()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            //Debug.Log("没有联网！！！");
            return 0;
        }
        if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        {
            //Debug.Log("使用Wi-Fi！！！");
            return 1;
        }
        if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
        {
            //Debug.Log("使用移动网络！！！");
            return 2;
        }
        else
        {
            return -1;
        }
    }
}
