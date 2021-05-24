using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidePlayer : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnMouseUp()
    {
        audioSource.Play();
    }
}
