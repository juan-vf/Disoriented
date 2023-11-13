using System.Collections.Generic;
using UnityEngine;

public class BackpackControllerTest : MonoBehaviour
{
    [SerializeField] private int _prefabsPerRow = 3;
    [SerializeField] private int _rowCount = 2;
    [SerializeField] private int _petsCollecteds = 0;
    [SerializeField] private int _sizeBackpack = 6;
    [SerializeField] private Transform _petTargetTransform = null;
    [SerializeField] private GameObject _petPrefab;
    private int _idPetToAdd;

    [Header("Events")]
    [SerializeField] private GrabEventManager _listenerIds;

    [SerializeField] private Grid _grid;
    private List<Vector3> _petsPositions = new List<Vector3>();
    // Start is called before the first frame update
    private void OnEnable()
    {
        _petsCollecteds = 0;
    }
    private void Start()
    {
        _idPetToAdd = -100;
        _petsCollecteds = 0;
        _grid = GetComponent<Grid>();
        _sizeBackpack = _rowCount * _prefabsPerRow;
        _petsPositions.Clear();
        GeneratePositions();
        // Debug.Log(_sizeBackpack);
        // PetEventsManager.GetCurrent.onSendPetData += AddPet;
        // PetEventsManager.GetCurrent.onGrabPet += AddPet;

        _listenerIds.onSendPetToListener += AddPet;
    }

    // Update is called once per frame
    void Update()
    {
        if (_petsCollecteds >= _sizeBackpack)
        {
            _petsCollecteds = 0;
        }
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
    public void AddPet(int id, int serialId)
    {
        _petsCollecteds += 1;
        // Debug.Log(_petsCollecteds >= _sizeBackpack);
        if (_petsCollecteds >= _sizeBackpack) { SceneEventController.GetCurrent.LoadWinScene(); _petsCollecteds = 0; Debug.Log("Se envio el evento"); return; }
        // if (!PlayerInputManager.getCurrent.getIsPickedUp) { return;}
        if (_idPetToAdd == serialId) { return; }
        // Debug.Log("Se agrego:  " + id);

        _idPetToAdd = serialId;
        Pet pet = PetsList.GetCurrent.GetPetById(id);
        GeneratePet(pet);
    }
    public void GeneratePet(Pet pet)
    {
        // Debug.Log(pet != null);
        if (_petsCollecteds <= 0)
        {
            // Manejar la situación cuando _petsCollecteds es menor o igual a cero
            Debug.Log("MASCOTA RECOLECTADAS MENOR A 0");
            return;
        }
        if (_grid != null)
        {
            if (_petsPositions[_petsCollecteds - 1] != null)
            {
                if (_petPrefab != null)
                {
                    if (pet != null)
                    {
                        GameObject petAdded = Instantiate(_petPrefab, _grid.GetCellCenterWorld(Vector3Int.FloorToInt(_petsPositions[_petsCollecteds - 1])), Quaternion.identity, transform);
                        if (petAdded == null) { Debug.Log("MASCOTA NIULLL"); }
                        // SetCamera(petAdded);
                        // Debug.Log("Creando", petAdded);
                        petAdded.GetComponent<PetController>().GetId = pet.GetId;
                    }
                }
            }
        }
    }
    void SetCamera(GameObject pet)
    {
        pet.GetComponent<LookCamera>().SetCamera(_petTargetTransform);
    }

}
