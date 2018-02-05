using System.Collections.Generic;
using Yishimu;

public class JsonDataManager : SingleTon<JsonDataManager>
{

    public void InitJsonData()
    {
        JsonManager.Instance.Json2List(Instance, "asd");
    }
}
