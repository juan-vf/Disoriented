using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectComponent : MonoBehaviour
{
    [SerializeField]private GrabEventManager _petGrabEvent;
    public bool PetToCollect(Rigidbody _rb)
    {
        Ray ray = new Ray(_rb.transform.position + _rb.transform.TransformDirection(Vector2.up * 0.5f), _rb.transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, .7f) && hit.transform.tag == "Pet"){
            _petGrabEvent.GrabPet(hit.transform.GetComponent<PetController>().GetSerialId);
            //IMPLEMENTAR EL MISMO EVENTO PARA DESTRUIR EL QUE CONINCIDA CON EL ID Y MANDAR A CREARLO
            return true;
        }else{return false;}
    }
}
