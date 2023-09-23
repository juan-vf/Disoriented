using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarriageEventController : MonoBehaviour
{
    private static CarriageEventController _current;

    void Awake()
    {
        _current = this; 
    }

    public event Action onChangeFullState;

    public void ChangeFullState()
    {
        onChangeFullState?.Invoke();
    }


    public static CarriageEventController GetCurrent { get { return _current; }  }
}
