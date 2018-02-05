
using UnityEngine;
using Yishimu;
public class Test : MonoBehaviour {

    Land land;
    public void Awake()
    {
        //Sige();
        land = new Land();
    }
    public void Start()
    {

       

        Debug.Log(JsonManager.Instance.Json2List(land, "test")[1].land_id);


        ////test  序列化 
        //UserData t2 = new UserData();
        //t2.id = 11;
        //t2.level = 1;
        //t2.money = 33;
        //t2.name = "dddd";

        //string str = JsonManager.Instance.JsonObj2String(t2);
        //f发送json数据
        //SocketHelper.Instance.SendMessage(str);
        //Debug.Log(str);

        // 反序列化
        //UserData t1 = new UserData();
        //t1 = JsonManager.Instance.JsonString2Obj<UserData>(str);
        //Debug.Log(t1.id + "  " + t1.level + "  " + t1.money + "  " + t1.name);
    }

}

public class Land
{
    public string land_id;
    public int type;
    public int value;
    public int weight;
}