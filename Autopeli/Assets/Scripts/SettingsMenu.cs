using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer MusicMixer;
    public AudioMixer SFXMixer;
    public Slider musicSlider;
    public Slider SFXSlider;
    public TMP_Dropdown qualityDropdown;

    private void Start()
    {
        GetMusicVolume();
        GetSfxVolume();
        qualityDropdown.value=QualitySettings.GetQualityLevel();
    }

    public void SetMusicVolume(float volume)
    {
        MusicMixer.SetFloat("volume", volume);
        if (volume == -40)
        {
            MusicMixer.SetFloat("volume", -80);
        }
    }

    public void GetMusicVolume()
    {
        float volume;
        if(MusicMixer.GetFloat("volume", out volume))
        {
            musicSlider.value=volume;
        }
        else
        {
            musicSlider.value = -20f;
        }
    }

    public void SetSfxVolume(float volume)
    {
        SFXMixer.SetFloat("volume", volume);
        if (volume == -40)
        {
            SFXMixer.SetFloat("volume", -80);
        }
    }

    public void GetSfxVolume()
    {
        float volume;
        if (SFXMixer.GetFloat("volume", out volume))
        {
            SFXSlider.value = volume;
        }
        else
        {
            SFXSlider.value = -20f;
        }
    }

    public void SetQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }
}
