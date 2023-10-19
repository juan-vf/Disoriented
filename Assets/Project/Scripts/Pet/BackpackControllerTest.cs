using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackControllerTest : MonoBehaviour
{
    [SerializeField] private int _prefabsPerRow = 3;
    [SerializeField] private int _rowCount = 2;
    [SerializeField] private int _petsCollecteds = 0;
    [SerializeField] private int _sizeBackpack;
    [SerializeField] private Transform _petTargetTransform;
    [SerializeField] private GameObject _petPrefab;
    
    private Grid _grid;
    private List<Vector3> _petsPositions = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        _petsCollecteds = 0;
        _grid = GetComponent<Grid>();
        _sizeBackpack = _rowCount * _prefabsPerRow;
        _petsPositions.Clear();
        GeneratePositions();
        PetEventsManager.GetCurrent.onSendPetData += AddPet;
        // PetEventsManager.GetCurrent.onGrabPet += AddPet;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void GeneratePositions()
    {
        for (int i = 0; i < _prefabsPerRow; i++)
        {
            for (int j = 0; j < _rowCount; j++)
            {
                Vector3Int cellPosition = new Vector3Int(j - _rowCount / 2, i - _prefabsPerRow / 2, 0);
                // Vector3 worldPosition = _grid.GetCellCenterWorld(cellPosition);
                _petsPositions.Add(cellPosition);
                // GameObject pet = Instantiate(_petPrefab, _grid.GetCellCenterWorld(cellPosition), Quaternion.identity, transform);
            }
        }
    }
    public void AddPet(int id)
    {
        // Debug.Log("LLEGO EVENTO: " + id);
        _petsCollecteds++;
        if (_petsCollecteds >= _sizeBackpack) { SceneEventController.GetCurrent.LoadWinScene(); Debug.Log("Se envio el evento"); return; }
        if (!PlayerInputManager.getCurrent.getIsPickedUp) { return; }
        Pet pet = PetsList.GetCurrent.GetPetById(id);
        GeneratePet(pet);
    }
    public void GeneratePet(Pet pet)
    {
        GameObject petAdded = Instantiate(_petPrefab, _grid.GetCellCenterWorld(Vector3Int.FloorToInt(_petsPositions[_petsCollecteds - 1])), Quaternion.identity, transform);
        SetCamera(petAdded);
        // Debug.Log("Creando", petAdded);
        petAdded.GetComponent<PetController>().GetId = pet.GetId;
    }
    void SetCamera(GameObject pet){
        pet.GetComponent<LookCamera>().SetCamera(_petTargetTransform);
    }

}
