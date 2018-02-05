
using UnityEngine;
using UnityEngine.UI;

public class ActiveController : MonoBehaviour
{

    private void OnEnable()
    {
        if (this.gameObject.GetComponent<Text>())
        {
            Color c1 = this.gameObject.GetComponent<Text>().color;
            Color c2 = this.gameObject.GetComponent<Text>().color;
            c1.a = 1;
            c2.a = 0;
            ActiveControl.ActiveWithColorTween(this.gameObject, c1, c2, ActiveControl.UIType.text);
        }
        else if (this.gameObject.GetComponent<Image>())
        {
            Color c1 = this.gameObject.GetComponent<Image>().color;
            Color c2 = this.gameObject.GetComponent<Image>().color;
            c1.a = 1;
            c2.a = 0;
            ActiveControl.ActiveWithColorTween(this.gameObject, c1, c2);
        }

    }
}
