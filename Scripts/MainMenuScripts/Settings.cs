using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField]GameObject SettingsWindow;
    [SerializeField] AudioMixer mainMixer;
    [SerializeField] Slider slider;

    public void SetActive()
    { 
        SettingsWindow.SetActive(true);
    }
    public void SetNotActive()
    {
        SettingsWindow.SetActive(false); 
    }
    public void SetVol() 
    {
        mainMixer.SetFloat("gameVolume", slider.value);
    }
}
