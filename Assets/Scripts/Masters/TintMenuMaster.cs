using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TintMenuMaster : MonoBehaviour
{
    public CentralPort central;
    public Fader tintFader;

    public GameObject buttons;

    public GameObject backButton;
    public GameObject retryButton;

    //==================================================================================================================================================================
    private void Awake()
    {
        central.inputHandler.OnLock += FadeIn;
        central.inputHandler.OnUnlock += FadeOut;

        tintFader.OnFadeInEnd += delegate ()
        {
            buttons.SetActive(true);

            if(central.heartsMaster.isNoUnits)
            {
                backButton.GetComponent<Button>().interactable = false;
                backButton.GetComponent<MouseEnterSound>().muted = true;

                retryButton.GetComponent<Button>().interactable = true;
                retryButton.GetComponent<MouseEnterSound>().muted = false;
            }
        };
    }

    //==================================================================================================================================================================
    public void FadeIn()
    {
        tintFader.StartFadeIn();
    }

    public void FadeOut()
    {
        buttons.SetActive(false);
        tintFader.StartFadeOut();
    }
}
