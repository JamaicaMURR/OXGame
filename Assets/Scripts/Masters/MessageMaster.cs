using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class MessageMaster : MonoBehaviour
{
    float _timer;
    int _lastPriority;

    Queue<string> messagesQueue;

    public CentralPort central;
    public Text textField;

    public Font font;

    public Color warning;
    public Color attention;
    public Color regular;

    public float messageTime = 1;

    void Awake()
    {
        central.inputHandler.OnPause += delegate () { ShowMessage("Pause", regular, 2); };
        central.inputHandler.OnUnPause += SetClean;
        central.inputHandler.OnPauserUsing += delegate () { ShowMessage("Light speed!", attention, 3); };

        central.heartsMaster.OnUnitLost += delegate () { ShowMessage("Life lost!", warning, 4); };
        central.heartsMaster.OnZeroUnits += delegate () { ShowMessage("Game Over", warning, 5); };

        central.mergeMaster.AtMerged += delegate (int i)
        {
            if(i > 1)
            {
                string text = i + " merged!";

                if(i > 8)
                    ShowMessage("Unbelievable! " + text, attention, 4);
                else if(i > 6)
                    ShowMessage("Aweesome!" + text, attention, 2);
                else if(i > 4)
                    ShowMessage("Nice!" + text, attention, 1);
                else if(i > 2)
                    ShowMessage(text, regular);
            }
        };
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if(_timer >= messageTime)
            SetClean();
    }

    void ShowMessage(string message, Color color)
    {
        ShowMessage(message, color, 0);
    }

    void ShowMessage(string message, Color color, int priority)
    {
        if(priority > _lastPriority)
        {
            textField.color = color;
            textField.text = message;
            _timer = 0;
        }
    }

    void SetClean()
    {
        textField.text = "";
        _timer = 0;
        _lastPriority = -1;
    }
}
