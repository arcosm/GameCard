using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class ApplicationController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void ExitGame()
    {
        Application.Quit();
    }

    public static bool isFristTime()
    {
        if (PlayerPrefs.GetString("FristTime") != "CThun")
            return true;
        return false;
    }

    public static void SetDefaultConfigs()
    {
        PlayerPrefs.SetString("FristTime", "CThun");
        EnableSoundSFX();
        EnableMusic();
        SetVolumeSFX(10);
        SetVolumeMusic(10);
    }

    //sound Configurations//
    //sfx//
    public static void EnableSoundSFX()
    {
        PlayerPrefs.SetInt("SFXSound", 1);
    }

    public static void DisableSoundSFX()
    {
        PlayerPrefs.SetInt("SFXSound", 0);
    }

    public static bool IsMuttedSoundSFX()
    {
        if (PlayerPrefs.GetInt("SFXSound") == 1)
            return true;

        return false;
    }

    public static void SetVolumeSFX(float volume)
    {
        PlayerPrefs.SetFloat("SFXSoundVolume", volume);
    }

    public static float GetVolumeSFX()
    {
        return PlayerPrefs.GetFloat("SFXSoundVolume");
    }

    //music//
    public static void EnableMusic()
    {
        PlayerPrefs.SetInt("Music", 1);
    }

    public static void DisableMusic()
    {
        PlayerPrefs.SetInt("Music", 0);
    }

    public static bool IsMuttedMusic()
    {
        if (PlayerPrefs.GetInt("Music") == 1)
            return true;

        return false;
    }
    public static void SetVolumeMusic(float volume)
    {
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public static float GetVolumeMusic()
    {
        return PlayerPrefs.GetFloat("MusicVolume");
    }
    //sound Configuration//
}