using Holoville.HOTween;
using UnityEngine;
using UnityEngine.UI;

public class ShadeControl  {

    public static void Active(GameObject o)
    {
        o.SetActive(true);
    }

    public static void UnActive(GameObject o)
    {
        o.SetActive(false);
    }

    public static void ActiveWithTween(GameObject o, float f = 0.5f)
    {
        Active(o);
        o.GetComponent<Image>().color = new Color(0, 0, 0, f);
        HOTween.From(o.GetComponent<Image>(), 0.2f, new TweenParms().Prop("color", new Color(0, 0, 0, 0)));
    }

    public static void UnActiveWithTween(GameObject o)
    {
        HOTween.To(o.GetComponent<Image>(), 0.2f, new TweenParms().Prop("color", new Color(0, 0, 0, 0)).OnComplete(UnActiveCallBack,o));
    }

    static void UnActiveCallBack(TweenEvent e)
    {
        UnActive(e.parms[0] as GameObject);
    }
}
