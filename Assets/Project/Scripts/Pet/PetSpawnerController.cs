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

    [Header("Events")]
    [SerializeField] private RequestSendLocation _enemyAndSpawner;
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
        Debug.Log(_spawnsList[0] + "" + _spawnsList[1] );
        Debug.Log(_spawnsList.Count);
      
        //Enviamos

        //Enviamos
        if (CarriageEventController.GetCurrent != null)
        { 
        CarriageEventController.GetCurrent.UpdateMaxCountCarriage(_spawnsList.Count);
        
        }
        
        //CONSIDERAR QUE AL TENER 2 SPAWNER EN SCENEA, EL ENEMIGO PIDE LA UBICACION Y LOS DOS SPAWNER LE ENVIARAN UNA MASCOTA.
        // PetEventsManager.GetCurrent.onEnemyRequestPet += SendPetPosition;
        // PetEventsManager.GetCurrent.onEnemyRequestPet += SendPetPosition;
        _enemyAndSpawner.onRequestLocation += SendPetPosition;
        
        // SendPetPosition();
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
        if(_spawnsList.Count == 0){
            return;
            //ACA YA NO HAY MASCOTAS PARA RECOGER
        }
        if(_spawnsList == null){
        //     CarriageEventController.GetCurrent.UpdateMaxCountCarriage(_spawnsList.Count);
        //     // PetEventsManager.GetCurrent.EnemyGoToPet(_spawnsList[1], _spawnsList[1].GetComponent<PetController>().GetSerialId);
            _enemyAndSpawner.SendLocation(_spawnsList[1]);
            _spawnsList.RemoveAt(1);
            // return;
        }
        CarriageEventController.GetCurrent.UpdateMaxCountCarriage(_spawnsList.Count);
        // PetEventsManager.GetCurrent.EnemyGoToPet(_spawnsList[0], _spawnsList[0].GetComponent<PetController>().GetSerialId);
        _enemyAndSpawner.SendLocation(_spawnsList[0]);
        Debug.Log("Envio location");
        _spawnsList.RemoveAt(0);
        // Actualiza los elementos dentro de la lista
        


    }

}
