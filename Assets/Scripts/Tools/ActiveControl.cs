using Holoville.HOTween;
using UnityEngine;
using UnityEngine.UI;

public class ActiveControl {

    public static void Active(GameObject o)
    {
        o.SetActive(true);
    }

    public static void UnActive(GameObject o)
    {
        o.SetActive(false);
    }

    public static void ActiveWithColorTween(GameObject o, float f = 0.5f)
    {
        Active(o);
        o.GetComponent<Image>().color = new Color(0, 0, 0, f);
        HOTween.From(o.GetComponent<Image>(), 0.2f, new TweenParms().Prop("color", new Color(0, 0, 0, 0)));
    }


    public enum UIType
    {
        text,
        image
    }
    public static void ActiveWithColorTween(GameObject o, Color now,Color to, UIType uiType = UIType.image)
    {
        Active(o);
        if (uiType == UIType.text)
        {
            o.GetComponent<Text>().color = now;
            HOTween.From(o.GetComponent<Text>(), 0.2f, new TweenParms().Prop("color", to));
        }
        else
        {
            o.GetComponent<Image>().color = now;
            HOTween.From(o.GetComponent<Image>(), 0.2f, new TweenParms().Prop("color", to));
        }
    }


    public static void UnActiveWithColorTween(GameObject o)
    {
        HOTween.To(o.GetComponent<Image>(), 0.2f, new TweenParms().Prop("color", new Color(0, 0, 0, 0)).OnComplete(UnActiveCallBack, o));
    }

    static void UnActiveCallBack(TweenEvent e)
    {
        UnActive(e.parms[0] as GameObject);
    }
}
