using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapSensor : MonoBehaviour
{
    public bool triggerState = false;

    public event Action OnTap1;
    public event Action OnTap2;

    private void OnMouseDown()
    {
        if(!triggerState)
        {
            if(OnTap1 != null)
                OnTap1();

            triggerState = true;
        }
        else
        {
            if(OnTap2 != null)
                OnTap2();

            triggerState = false;
        }
    }
}
