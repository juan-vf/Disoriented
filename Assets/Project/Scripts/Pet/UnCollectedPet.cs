using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnCollectedPet : MonoBehaviour
{
    private bool _isPicked;
    private PetController _petController;
    private bool _enabledToCollect;
    void Start()
    {

        _petController = GetComponent<PetController>();
        PetEventsManager.GetCurrent.onBackPackFull += BackPackUpdates;
        // PetEventsManager.GetCurrent.onGrabPet += Picked;
    }
    private void Update() {
    }
    private void OnCollisionStay(Collision other) {
        bool tag = other.gameObject.tag == "Player";
        if(tag && PlayerInputManager.getCurrent.getIsPickedUp && _enabledToCollect){
            Picked();
        }
    }
    private void Picked(){
        PetEventsManager.GetCurrent.SendPetData(_petController.GetId);
        Destroy(gameObject);
    }
    private void BackPackUpdates(bool value){
        _enabledToCollect = value;
    }
    public bool GetIsPickedUp{get{return _isPicked;}}
}
