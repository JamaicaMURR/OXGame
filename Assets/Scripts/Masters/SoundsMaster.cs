using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsMaster : MonoBehaviour
{
    public CentralPort central;
    public XBehavior xBehavior;

    public AudioSource soundSource;
    public AudioSource musicSource;

    public AudioClip xMovingSound;
    public AudioClip heartLostSound;
    public AudioClip gameOverSound;

    public AudioClip lowMergeSound;
    public AudioClip highMergeSound;

    public AudioClip onPauseSound;

    public AudioClip onLightSpeedSound;

    private void Awake()
    {
        xBehavior.OnSuccefulMove += delegate () { soundSource.PlayOneShot(xMovingSound); };

        central.pausersMaster.OnUnitLost += delegate () { soundSource.PlayOneShot(onLightSpeedSound); };
        central.pausersMaster.OnZeroUnits += delegate () { soundSource.PlayOneShot(onLightSpeedSound); };

        central.heartsMaster.OnUnitLost += delegate () { soundSource.PlayOneShot(heartLostSound); };

        central.heartsMaster.OnZeroUnits += delegate () { soundSource.PlayOneShot(gameOverSound); };

        central.mergeMaster.AtMerged += delegate (int i)
        {
            if(i < 3)
                soundSource.PlayOneShot(lowMergeSound);
            else
                soundSource.PlayOneShot(highMergeSound);
        };

        central.inputHandler.OnPause += delegate () { soundSource.PlayOneShot(onPauseSound); };
        central.inputHandler.OnUnPause += delegate () { soundSource.PlayOneShot(onPauseSound); };
    }
}
