using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SensitivewordFilter
{

    private static int minMatchType = 1;      //最小匹配规则
    private static int maxMatchType = 2;      //最大匹配规则

    public List<string> sensitiveWordList = new List<string>(); //词库

    public SensitivewordFilter()
    {
        sensitiveWordList = new SensitiveWordInit().list;
    }

    /// <summary>
    /// 判断文字是否包含敏感字符
    /// </summary>
    public bool isContaintSensitiveWord(string txt, int matchType)
    {
        bool flag = false;
        for (int i = 0; i < txt.Length; i++)
        {
            int matchFlag = this.CheckSensitiveWord(txt, i, matchType); //判断是否包含敏感字符
            if (matchFlag > 0)
            {    //大于0存在，返回true
                flag = true;
            }
        }
        return flag;
    }

    /// <summary>
    /// 检查敏感词规则
    /// </summary>
    /// <param name="txt"></param>
    /// <param name="beginIndex"></param>
    /// <param name="matchType"></param>
    /// <returns></returns>
    public int CheckSensitiveWord(string txt, int beginIndex, int matchType)
    {
        bool flag = false;    //敏感词结束标识位：用于敏感词只有1位的情况
        int matchFlag = 0;     //匹配标识数默认为0
        char word = '0';
        List<string> nowList = sensitiveWordList;
        for (int i = beginIndex; i < txt.Length; i++)
        {
            word = txt[i];
            nowList = nowList.Where(o => o.Contains(word.ToString())).ToList();           //获取指定key

            if (nowList != null && nowList.Count > 0)
            {
                if (CheckKey(nowList,txt,i))
                {
                    //找到相应key，匹配标识+1 
                    matchFlag++;
                }
                //存在，则判断是否为最后一个
                List<string> l = nowList.Where(o => o.Length == 1).ToList();
                //如果为最后一个匹配规则,结束循环，返回匹配标识数
                if (l != null && l.Count > 0)
                {
                    flag = true;       //结束标志位为true   
                    if (minMatchType == matchType)
                    {    //最小规则，直接返回,最大规则还需继续查找
                        break;
                    }
                }
            }
            else
            {     //不存在，直接返回
                break;
            }
        }
        if (flag)
        {
            matchFlag = 1;
        }
        //else if (matchFlag < 2)
        //{
        //    matchFlag = 0;
        //}

        return matchFlag;
    }


    public bool CheckKey(List<string> n,string txt,int indexOf)
    {
        for (int i = 1; i <= txt.Length - indexOf; i++)
        {
            string key = txt.Substring(indexOf, i);
            List<string> m = n.Where(o => o.Equals(key)).ToList();
            if (m != null && m.Count>0)
            {
                return true;
            }
        }
        return false;
    }
}
