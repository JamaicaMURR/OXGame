using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sound;

    private void OnMouseEnter()
    {
        audioSource.PlayOneShot(sound);
    }
}
