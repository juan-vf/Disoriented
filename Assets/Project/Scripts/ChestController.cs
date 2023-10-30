using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public GameObject prefab;
    private void Start() {
        
        ChestEventSystem.current.onGrabPet += DropPet;

    }

    private void DropPet(){
        ChestEventSystem.current.DropPet(prefab);
    }

}
