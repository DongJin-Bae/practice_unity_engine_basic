using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public Action KeyAction = null;

    public void OnUpdate()
    {
        if (!Input.anyKey) return;
        if (KeyAction == null) return;

        KeyAction.Invoke();
    }
}
