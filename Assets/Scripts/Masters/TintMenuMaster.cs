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

    public Button backButton;
    public Button retryButton;

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
                backButton.interactable = false;
                retryButton.interactable = true;
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
