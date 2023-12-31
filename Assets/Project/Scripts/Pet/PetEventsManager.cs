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
    public event Action onCallEnemieToTransport;
    public event Action<int> onEnemyGrab;
    public event Action<GameObject, int> onEnemyGoToPet;
    public event Action onEnemyRequestPet;
    public event Action<int> onDestroyPetById;
    public void GrabPet(){onGrabPet?.Invoke();}
    public void SendPetData(int id){onSendPetData?.Invoke(id);}
    public void BackPackFull(bool isFull){onBackPackFull?.Invoke(isFull);}
    public void CallEnemieToTransport(){onCallEnemieToTransport?.Invoke();}
    public void EnemyGrab(int serialId){onEnemyGrab?.Invoke(serialId);}
    public void EnemyGoToPet(GameObject pet, int id){onEnemyGoToPet?.Invoke(pet, id);}
    public void EnemyRequestPet(){onEnemyRequestPet?.Invoke();}
    public void DestroyPetById(int id){onDestroyPetById?.Invoke(id);}
}
