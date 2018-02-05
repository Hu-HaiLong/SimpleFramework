

using UnityEngine;

public class CATALOGUE_DEFINE {

    public static string URL_UNITY_FILEPATH = Application.dataPath + "/Plugins/Android/assets/YSMP01Db.db";

    public static string URL_IPHONE_FILEPATH = Application.persistentDataPath + "/YSMP01Db.db";

    public static string URL_ANDROID_FILEPATH = Application.persistentDataPath + "/YSMP01Db.db";

    public static string URL_UNITY_DBCON = "data source=" + Application.dataPath + "/Plugins/Android/assets/YSMP01Db.db";

    public static string URL_IPHONE_DBCON = "data source=" + Application.persistentDataPath + "/YSMP01Db.db";

    public static string URL_ANDROID_DBCON = "URI=file:" + Application.persistentDataPath + "/YSMP01Db.db";

    public static string TEXTURE_PATH = "Textures/TextureTrial/";
}
