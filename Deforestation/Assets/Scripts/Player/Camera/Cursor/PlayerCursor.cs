using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCursor : MonoBehaviour
{
    private void OnEnable()
    {
        Disable();
    }

    public void Enable()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Disable()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}