using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedPet : MonoBehaviour
{
    private PetController _petController;
    void Start()
    {
        _petController = GetComponent<PetController>();
        transform.localScale = Vector3.one * .25f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
