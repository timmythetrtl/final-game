using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    // Start is called before the first frame update

    public void SetMusicVolume()
    {
        float mVolume = musicSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(mVolume)*20);
        float sVolume = sfxSlider.value;
        myMixer.SetFloat("sfx", Mathf.Log10(sVolume) * 20);
    }
}
