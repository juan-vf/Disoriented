using System.Collections.Generic;
using UnityEngine;

public class PetSpawnerController : MonoBehaviour
{
    [SerializeField]private GameObject _prefab;
    [SerializeField]private int _maxSpawnsPets;
    [SerializeField]private Vector3 _center;
    [SerializeField]private float _range;

    // Lista de objetos creados
    [SerializeField] private List<GameObject> _spawnsList;
    private PetSpawner _petSpawner;
    [SerializeField] private float _minHeight;
    [SerializeField] private float _maxHeight;
    [SerializeField] private bool _callEnemieToTransport = false;
    // Start is called before the first frame update
    void Start()
    {
        _center = transform.position;
        _petSpawner = gameObject.AddComponent<PetSpawner>();
        _petSpawner.GetPrefab = _prefab;
        _petSpawner.GetMaxSpawnerPets = _maxSpawnsPets;
        _petSpawner.GetCenter = _center;
        _petSpawner.GetRange = _range;
        _petSpawner.GetMaxHeight = _maxHeight;
        _minHeight = transform.position.y;
        _petSpawner.GetMinHeight = _minHeight;

        _petSpawner.Spawn();
        _spawnsList = _petSpawner.GetSpawnList;

        PetEventsManager.GetCurrent.onEnemyRequestPet += SendPetPosition;
        // PetEventsManager.GetCurrent.onEnemyRequestPet += SendPetPosition;
    }
    private void Update() {


        if(_callEnemieToTransport){
            //LANZA EVENTO PARA QUE LA MASCOTA CAMBIE A MODO TRANSPORTE
            // PetEventsManager.GetCurrent.CallEnemieToTransport();
            _callEnemieToTransport = false;
        }
        if(_spawnsList.Count == 0){
            //Deja de estar en modo transporte
            _callEnemieToTransport = false;
        }
    
    }
    void DeleteBySerialId(int id){
        foreach (GameObject pet in _spawnsList)
        {
            if(pet.GetComponent<PetController>().GetSerialId == id){
                _spawnsList.Remove(pet);
            }
        }
    }
    void SendPetPosition(){
        PetEventsManager.GetCurrent.EnemyGoToPet(_spawnsList[0], _spawnsList[0].GetComponent<PetController>().GetSerialId);
        _spawnsList.RemoveAt(0);
    }
}
