using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Yishimu;

public class SensitiveWordInit {

    private static string ENCODING = "GBK";    //字符编码
    private static string fileAddress;

    public List<string> list = new List<string>(); //词库

    public SensitiveWordInit()
    {
        LoadSensitiveWords();
    }

    public void LoadSensitiveWords()
    {
        fileAddress = Application.dataPath + "/Resources/Text/CensorWords.txt";
        list = ReadTextFileToList(fileAddress);
    }

    /// <summary>
    /// text => list
    /// </summary>
    /// <returns></returns>
    public static List<string> ReadTextFileToList(string fileAddress)
    {
        List<string> list = new List<string>();

        try
        {
            FileStream fs = new FileStream(fileAddress, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            //StreamReader 读文件 
            sr.BaseStream.Seek(0, SeekOrigin.Begin);

            //从数据流中读取每一行
            string tmp = sr.ReadLine();
            while (tmp != null)
            {
                list.Add(tmp);
                tmp = sr.ReadLine();
            }
            //关闭此StreamReader对象 
            sr.Close();
            fs.Close();
        }
        catch
        {
            //
        }
        return list;
    }
}
