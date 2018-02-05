using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectStaticControl : MonoBehaviour
{

    public List<Sprite> EffectStatic = new List<Sprite>();
    public float speed = 0.15f;
    public bool loop = false;
    public int loopTimes = 1;

    int index = 0;
    float time = 0;

    void Update()
    {
        if(loop)
        {
            Loop();
        }
        else
        {
            NotLoop();
        }
    }


    void Loop()
    {
        time += Time.deltaTime;
        if (time > speed)
        {
            if (index < EffectStatic.Count - 1)
            {
                this.gameObject.GetComponent<Image>().sprite = EffectStatic[index];
                index++;
            }
            else
            {
                this.gameObject.GetComponent<Image>().sprite = EffectStatic[index];
                index = 0;
                if (loopTimes != -1)
                {
                    loopTimes--;
                    if (loopTimes == 0)
                    {
                        Destroy(this.gameObject);
                    }
                }
            }
            time = 0;
        }
    }

    void NotLoop()
    {
        time += Time.deltaTime;
        if (time > speed)
        {
            if (index < EffectStatic.Count - 1)
            {
                this.gameObject.GetComponent<Image>().sprite = EffectStatic[index];
                index++;
            }
            else
            {
                Destroy(this.gameObject);
            }
            time = 0;
        }
    }
}
