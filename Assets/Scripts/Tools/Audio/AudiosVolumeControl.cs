using System;
using UnityEngine;
using UnityEngine.UI;

public class AudiosVolumeControl : VolumnControl
{
    private void OnEnable()
    {
        this.gameObject.GetComponent<Slider>().value = AudioManager.Instance.GetAudioVolume();
    }

    public override void ChangeVolume()
    {
        AudioManager.Instance.audioSetVolume(this.gameObject.GetComponent<Slider>().value);
    }
}
