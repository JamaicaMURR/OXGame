using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class ButtonsHandler : MonoBehaviour
{
    public SoundOptionsHolder soundOptionsHolder;

    public event Action OnWipeRecord;

    public void StartGame()
    {
        soundOptionsHolder.RememberVolume();
        SceneManager.LoadScene("Field");
    }

    public void Quit()
    {
        soundOptionsHolder.RememberVolume();
        Application.Quit();
    }

    public void WipeRecord()
    {
        if(OnWipeRecord != null)
            OnWipeRecord();
    }
}
