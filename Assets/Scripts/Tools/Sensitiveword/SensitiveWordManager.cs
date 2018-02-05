using Yishimu;
using UnityEngine;

public class SensitiveWordManager : SingleTon<SensitiveWordManager> {


    SensitivewordFilter filter;

	public bool CheckSensitiveword(string text)
    {
        filter = new SensitivewordFilter();
        return filter.isContaintSensitiveWord(text, 1);
    }
}
