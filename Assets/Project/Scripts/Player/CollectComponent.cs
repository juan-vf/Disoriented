using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectComponent : CharacterBaseComponent
{

    public GameObject _itemPrefab;
    private Rigidbody _rb;
    public CollectComponent(Rigidbody rigidbody){ _rb = rigidbody;}
    public override void Process()
    {
    }

    public override void Restart()
    {
        throw new System.NotImplementedException();
    }

    public override void Start()
    {
        throw new System.NotImplementedException();
    }

    public override void Update()
    {
        throw new System.NotImplementedException();
    }
    public bool PetToCollect()
    {
        Ray ray = new Ray(_rb.transform.position + _rb.transform.TransformDirection(Vector2.up * 0.5f), _rb.transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, .7f) && hit.transform.tag == "Pet"){
            // Debug.Log("PARA MANDAR EVBENTOOTOOTOTOT");
            PetEventsManager.GetCurrent.GrabPet(hit.transform.GetComponent<PetController>().GetSerialId);
            //IMPLEMENTAR EL MISMO EVENTO PARA DESTRUIR EL QUE CONINCIDA CON EL ID Y MANDAR A CREARLO
            return true;
        }else{return false;}
    }
}
