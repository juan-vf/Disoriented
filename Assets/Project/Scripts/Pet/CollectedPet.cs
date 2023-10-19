using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedPet : MonoBehaviour
{
    private PetController _petController;
    void Start()
    {
        _petController = GetComponent<PetController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
