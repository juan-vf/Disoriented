using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PetController : MonoBehaviour
{
    [SerializeField]
    private int _id;
    private int _serialId;
    private Pet _pet;
    private Mesh _mesh;
    // private Material _Material;
    private String _name;
    private String _description;
    private MeshFilter _meshFilter;
    private MeshRenderer _meshRenderer;
    private int PetsCount;
    // Start is called before the first frame update
    void Start()
    {
        _pet = PetsList.GetCurrent.GetPetById(_id);
        _meshFilter = GetComponent<MeshFilter>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshFilter.mesh = _pet.GetMesh;
        _meshRenderer.material = _pet.GetMaterial;
        _name = _pet.GetName;
        _description = _pet.GetDescription;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public int GetId{get{return _id;} set{_id = value;}}
    public int GetSerialId{get{return _serialId;} set{_serialId = value;}}
    public Pet GetPet{get{return _pet;}}
}
