/*
 * Title:  SimpleFrameWork
 * 
 * Description: 平台名称定义，获取
 * 
 * Author: HHL
 * 
 * Data: 2018/2/2
 */
using UnityEditor;

public class Platform
{
    public static string GetPlatformFolder(BuildTarget target)
    {
        switch (target)
        {
            case BuildTarget.Android:
                return "Android";
            case BuildTarget.iOS:
                return "IOS";
            case BuildTarget.StandaloneWindows:
            case BuildTarget.StandaloneWindows64:
                return "Windows";
            default:
                return null;
        }
    }
}