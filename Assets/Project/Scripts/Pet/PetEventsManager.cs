using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetEventsManager : MonoBehaviour
{
    private static PetEventsManager _current;
    public static PetEventsManager GetCurrent{get{return _current;}}
    
    private void Awake()
    {
        _current = this;
    }
    public event Action onGrabPet;
    public event Action<int> onSendPetData;
    public event Action<bool> onBackPackFull;
    public void GrabPet()
    {
            onGrabPet?.Invoke();
    }
    public void SendPetData(int id){
            onSendPetData?.Invoke(id);
    }
    public void BackPackFull(bool isFull){
        onBackPackFull?.Invoke(isFull);
    }
}
