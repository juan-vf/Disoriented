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
    public event Action<int> onAddPet;
    public event Action<int> onUpdateMaxCountCarriage;

    public void ChangeFullState()
    {
        onChangeFullState?.Invoke();
    }
    public void AddPet(int id)
    { 
        onAddPet?.Invoke(id);
    }
    public void UpdateMaxCountCarriage(int count)
    {
        onUpdateMaxCountCarriage?.Invoke(count);
    }
    

    public static CarriageEventController GetCurrent { get { return _current; } }
    
}
