using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorDetector : MonoBehaviour
{
    public bool cursorOver;

    private void OnMouseEnter()
    {
        cursorOver = true;
    }

    private void OnMouseExit()
    {
        cursorOver = false;
    }

}
