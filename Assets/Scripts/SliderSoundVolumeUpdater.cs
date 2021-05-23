using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSoundVolumeUpdater : MonoBehaviour
{
    public Slider slider;
    public AudioSource source;

    private void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        slider.value = source.volume;
    }
}
