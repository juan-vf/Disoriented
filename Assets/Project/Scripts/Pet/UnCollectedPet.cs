using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnCollectedPet : MonoBehaviour
{
    private bool _isPicked;
    private PetController _petController;
    [SerializeField] private bool _enabledToCollect;
    void Start()
    {

        _petController = GetComponent<PetController>();
        PetEventsManager.GetCurrent.onBackPackFull += BackPackUpdates;
        PetEventsManager.GetCurrent.onDestroyPetById += PickedUpByEnemy;
        PetEventsManager.GetCurrent.onGrabPet += Picked;
        // PetEventsManager.GetCurrent.onSendPetData += Picked;
    }
    private void Update()
    {
    }
    private void OnCollisionStay(Collision other)
    {
    }
    public void Picked(int id)
    {
        if(_petController.GetSerialId == id){

            PetEventsManager.GetCurrent.SendPetData(_petController.GetId);

            // Debug.Log("ME DESTRUYO");
            // transform.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
    private void BackPackUpdates(bool value)
    {
        _enabledToCollect = value;
    }
    void PickedUpByEnemy(int id)
    {
        if (this == null) { return; }
        if (_petController.GetSerialId == id) { Destroy(gameObject); }
    }
    public bool GetIsPickedUp { get { return _isPicked; } }
}
