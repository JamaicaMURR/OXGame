using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOptionsHolder : MonoBehaviour
{
    string soundsVolumeTag = "soundsVolume";
    string musicVolumeTag = "musicVolume";

    public AudioSource soundsSource;
    public AudioSource musicSource;

    public bool setVolumePrefsOnAwake;

    private void Awake()
    {
        if(setVolumePrefsOnAwake)
            SetVolume();
    }

    public void RememberVolume()
    {
        PlayerPrefs.SetFloat(soundsVolumeTag, soundsSource.volume);
        PlayerPrefs.SetFloat(musicVolumeTag, musicSource.volume);
    }

    public void SetVolume()
    {
        soundsSource.volume = PlayerPrefs.GetFloat(soundsVolumeTag);
        musicSource.volume = PlayerPrefs.GetFloat(musicVolumeTag);
    }
}
