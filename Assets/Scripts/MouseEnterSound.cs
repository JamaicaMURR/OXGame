using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEnterSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sound;

    public bool muted = false;

    private void OnMouseEnter()
    {
        if(!muted)
            audioSource.PlayOneShot(sound);
    }
}
