using System;
using UnityEngine;
using UnityEngine.UI;

public class BGMVolumeControl :  VolumnControl
{
    private void OnEnable()
    {
        this.gameObject.GetComponent<Slider>().value = AudioManager.Instance.GetBGMVolume();
    }

    public override void ChangeVolume()
    {
        AudioManager.Instance.BGMSetVolume(this.gameObject.GetComponent<Slider>().value);
    }
}
