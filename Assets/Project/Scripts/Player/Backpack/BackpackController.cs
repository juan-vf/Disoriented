using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackController : MonoBehaviour
{
    [SerializeField]
    private int _sizeBackpack = 0;
    private int _petsCollecteds = 0;
    [SerializeField]private List<Transform> _petsBoxesPositions;
    [SerializeField]private GameObject _petPrefab;
    private GameObject[] _petList;
    private bool _fullyBackPack = false;
    void Start()
    {
        PetEventsManager.GetCurrent.onSendPetData += AddPet;
    }
    void Update()
    {
        _fullyBackPack = _petsCollecteds >= _sizeBackpack;
        PetEventsManager.GetCurrent.BackPackFull(!_fullyBackPack);
    }
    public void AddPet(int id){
        _petsCollecteds++;
        if(_petsCollecteds >= _sizeBackpack){SceneEventController.GetCurrent.LoadWinScene(); Debug.Log("Se envio el evento"); return;}
        if(!PlayerInputManager.getCurrent.getIsPickedUp){return;}
        Pet pet = PetsList.GetCurrent.GetPetById(id);
        GeneratePet(pet);
    }
    public void GeneratePet(Pet pet){
        GameObject petAdded = Instantiate(_petPrefab, _petsBoxesPositions[_petsCollecteds-1].position, Quaternion.identity);
        petAdded.transform.parent = this.transform;
        petAdded.GetComponent<PetController>().GetId = pet.GetId;
        // ChargePetData(petAdded, pet);
    }
    /*
    public void ChargePetData(GameObject pet, Pet petSO){
        pet.GetComponent<MeshFilter>().mesh = petSO.GetMesh;
       MeshFilter _meshFilter = pet.GetComponent<MeshFilter>();
       MeshRenderer _meshRenderer = pet.GetComponent<MeshRenderer>();
       Transform transform = pet.GetComponent<Transform>();
       transform.localScale = new Vector3(.5f,.5f,.5f);
       _meshFilter.mesh = petSO.GetMesh;
       _meshRenderer.material = petSO.GetMaterial;
    }
    */
    
}
