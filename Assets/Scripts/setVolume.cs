using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class setVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public string exposedParameterName;
    public float musicValue, fxValue;

    public void Start()
    {
        musicValue = PlayerPrefs.GetFloat("musicVol");
        fxValue = PlayerPrefs.GetFloat("fxVol");
        SetMusicLevel(musicValue);
        SetFXLevel(fxValue);
    }


    public void SetMusicLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("musicVol", sliderValue);
    }

    public void SetFXLevel(float sliderValue)
    {
        mixer.SetFloat("fxVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("fxVol", sliderValue);
    }
}
