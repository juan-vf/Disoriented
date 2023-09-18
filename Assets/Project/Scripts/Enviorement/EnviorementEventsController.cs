using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class EnviorementEventsController : MonoBehaviour
{
    private static EnviorementEventsController _current;
    private void Awake()
    {
        _current = this;
    }
    public event Action<bool> onHiddenPlayer;
    public void HiddenPlayer(bool isHidden){
        onHiddenPlayer?.Invoke(isHidden);
    }
    public static EnviorementEventsController GetCurrent{get{return _current;}}
}
