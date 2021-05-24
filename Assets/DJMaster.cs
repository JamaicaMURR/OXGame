using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJMaster : MonoBehaviour
{
    int _chosen = 0;

    public AudioSource audioSource;

    public AudioClip[] playlist;

    public float checkingPeriod = 5;

    private void Start()
    {
        StartCoroutine("Work");
    }

    IEnumerator Work()
    {
        while(true)
        {
            if(!audioSource.isPlaying)
                PlayNext();

            yield return new WaitForSeconds(checkingPeriod);
        }
    }

    void PlayNext()
    {
        if(_chosen >= playlist.Length)
            _chosen = 0;

        audioSource.PlayOneShot(playlist[_chosen]);

        _chosen++;
    }
}
