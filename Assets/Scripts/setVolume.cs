using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class setVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public string exposedParameterName;

    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat(exposedParameterName, Mathf.Log10(sliderValue) * 20);
    }
}
