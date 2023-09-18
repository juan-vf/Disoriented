using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPet", menuName = "Pet")]
public class Pet : ScriptableObject
{
    /*
        Masha-Material-Audio
    */
    // [SerializeField]
    // private SkinnedMeshRenderer _Mesh;
    [SerializeField]private Mesh _mesh;
    [SerializeField] private Material _Material;
    [SerializeField]private int _id;
    [SerializeField] private String _name;
    [SerializeField] private String _description;

    public Mesh GetMesh{get{return _mesh;}}
    public Material GetMaterial{get{return _Material;}}
    public int GetId{get{return _id;}}
    public String GetName{get{return _name;}}
    public String GetDescription{get{return _description;}}

}
