using Mono.Data.Sqlite;
using Yishimu;
using System.IO;
using UnityEngine;

public class DBManager : SingleTon<DBManager>
{
    public  string conn;//Path to database.
    public  SQLiteHelper db;

    SqliteDataReader reader;

    bool isNew = true;

    public void init()
    {

            //创建数据库名称为YSMP01Db.db
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        conn = CATALOGUE_DEFINE.URL_UNITY_DBCON;
        if (File.Exists(CATALOGUE_DEFINE.URL_UNITY_FILEPATH))
        {
            isNew = false;
        }
        db = new SQLiteHelper(conn);
#elif UNITY_ANDROID
        //安卓特殊处理  。。。。
        conn = CATALOGUE_DEFINE.URL_ANDROID_DBCON;
        if (File.Exists(CATALOGUE_DEFINE.URL_ANDROID_FILEPATH))
        {
            db = new SQLiteHelper(conn);
            isNew = false;
        }
        else {  
        //如果数据库文件没有被创建，则创建数据库文件  
        WWW loadDB = new WWW ("jar:file://" + Application.dataPath + "!/assets/" + "YSMP01Db.db");  
        while (!loadDB.isDone) {
        }
         //拷贝至规定的地方
        File.WriteAllBytes (CATALOGUE_DEFINE.URL_ANDROID_FILEPATH, loadDB.bytes);  
  
        //建立数据库连接  
         //db = new SQLiteHelper(conn); //直接这样不行 第一次会抛异常
            if (File.Exists(CATALOGUE_DEFINE.URL_ANDROID_FILEPATH))
            {
                db = new SQLiteHelper(conn);
                isNew = false;
            }
        } 
#elif UNITY_IPHONE
        conn =  CATALOGUE_DEFINE.URL_IPHONE_DBCON;
        if (!File.Exists(CATALOGUE_DEFINE.URL_IPHONE_FILEPATH))
        {
            isNew = true;
        }
#endif

        //if (isNew)//!PlayerPrefs.HasKey("isInit")
        //{
        //    db.CreateTable(DBUserData.UserTable, new string[] { DBUserData.User_ID, DBUserData.User_NAME, DBUserData.User_LEVEL, DBUserData.User_MONEY, DBUserData.User_SKILL_ID },
        //        new string[] { "INTEGER", "TEXT", "INTEGER", "INTEGER", "TEXT" }, new string[] { "PRIMARY KEY    AUTOINCREMENT", "", "", "", "" });

        //    db.InsertValues(DBUserData.UserTable,new string[] { DBUserData.User_NAME, DBUserData.User_LEVEL, DBUserData.User_MONEY, DBUserData.User_SKILL_ID }, new string[] {"'小七'", "'1'", "'100'", "'0,1,2'" });


        //    db.CreateTable(DBSkillData.SkillTable, new string[] { DBSkillData.Skill_ID, DBSkillData.SKill_NAME, DBSkillData.Skill_Damage, DBSkillData.Skill_Movement },
        //        new string[] { "INTEGER", "TEXT", "INTEGER", "TEXT" }, new string[] { "PRIMARY KEY    AUTOINCREMENT", "", "", "" });

        //    db.InsertValues(DBSkillData.SkillTable, new string[] { "'1'", "'zha'", "'100'", "'11'" });

        //    PlayerPrefs.SetInt("isInit", 1);

        //    isNew = false;
        //}
    }

    public  void CloseDB()
    {
        db.CloseConnection();
    }
    public  void OpenDB()
    {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        db = new SQLiteHelper(conn);
#elif UNITY_ANDROID
        //安卓特殊处理  。。。。
        conn = CATALOGUE_DEFINE.URL_ANDROID_DBCON;
        if (File.Exists(CATALOGUE_DEFINE.URL_ANDROID_FILEPATH))
        {
            db = new SQLiteHelper(conn);
            isNew = false;
        }
        else
        {
            //如果数据库文件没有被创建，则创建数据库文件  
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/" + "YSMP01Db.db");
            while (!loadDB.isDone)
            {
            }
            //拷贝至规定的地方
            File.WriteAllBytes(CATALOGUE_DEFINE.URL_ANDROID_FILEPATH, loadDB.bytes);

            //建立数据库连接  
            db = new SQLiteHelper(conn);
        }
#endif
    }
}
