using UnityEngine;
using Yishimu;

public class MouseClickControl : MonoBehaviour{

    [SerializeField]
    private GameObject mouseEff;
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseEffect();
            MouseAudioPlay();
        }

        //if (Input.GetMouseButtonDown(1))
        //{
        //    GuideManager.Instance.Init();
        //    Debug.Log("init");
        //}

        //if (Input.GetMouseButtonDown(2))
        //{
        //    GuideManager.Instance.OnClick(this.gameObject, false);
        //    Debug.Log("next");
        //}
    }

    void MouseEffect()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mousePositionOnScreen = Input.mousePosition;
        mousePositionOnScreen.z = screenPosition.z;
        Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);
        GameObject o = Instantiate(mouseEff, mousePositionInWorld, Quaternion.identity);
    }

    void MouseAudioPlay()
    {
        try
        {
            AudioManager.Instance.SoundPlay(AUDIO_DEFINE.AUDIO_MOUSE);
        }
        catch 
        {
            Debug.Log("请运行初始场景");
        }
    }
}
