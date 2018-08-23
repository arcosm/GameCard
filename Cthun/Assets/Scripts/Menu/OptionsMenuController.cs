using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuController : MonoBehaviour
{
    public Toggle soundSFX, music;
    public Slider soundSFXVolume, musicVolume;

    // Use this for initialization
    void Start()
    {
        if (ApplicationController.isFristTime())
        {
            ApplicationController.SetDefaultConfigs();
        }

        soundSFX.isOn = ApplicationController.IsMuttedSoundSFX();
        music.isOn = ApplicationController.IsMuttedMusic();
        soundSFXVolume.value = ApplicationController.GetVolumeSFX();
        musicVolume.value = ApplicationController.GetVolumeMusic();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetSFXSound()
    {
        if (soundSFX.isOn)
        {
            ApplicationController.EnableSoundSFX();
        }
        else
        {
            ApplicationController.DisableSoundSFX();
        }
    }

    public void SetMusic()
    {
        if (music.isOn)
        {
            ApplicationController.EnableMusic();
        }
        else
        {
            ApplicationController.DisableMusic();
        }
    }

    public void SetVolumeSFX()
    {
        ApplicationController.SetVolumeSFX(soundSFXVolume.value);
    }

    public void SetVolumeMusic()
    {
        ApplicationController.SetVolumeMusic(musicVolume.value);
    }
}