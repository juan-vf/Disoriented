using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class EnemieManagmentEvent : MonoBehaviour
{
    private static EnemieManagmentEvent _current;
    public static EnemieManagmentEvent GetCurrent { get { return _current; } }

    private void Awake()
    {
        _current = this; 
    }

    public event Action onEnableScanner;
    public event Action onTellGrandson;

    public void EnableScanner() { onEnableScanner?.Invoke(); }
    public void TellGrandson() { onTellGrandson?.Invoke(); }

}
