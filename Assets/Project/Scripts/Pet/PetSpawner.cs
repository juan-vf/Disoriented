using System.Collections.Generic;
using UnityEngine;

public class PetSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _maxSpawnsPets;
    [SerializeField] private Vector3 _center;
    [SerializeField] private float _range;
    [SerializeField]private float _minHeight;
    [SerializeField]private float _maxHeight;
    [SerializeField] private List<GameObject> _spawnsList = new List<GameObject>();

    // Lista de objetos creados
    private void Start() {
    }
    public void Spawn() {
        // List<int> SerialIds = new List<int>();

        while(_spawnsList.Count < _maxSpawnsPets){
            GameObject spawn = Instantiate(_prefab, _center, Quaternion.identity);
            int randomId = (int)Random.Range(1f, PetsList.GetCurrent.GetCount + 1);
            // spawn.GetComponent<PetController>().GetSerialId = PetsList.GetCurrent.AgregarNumeroUnico(PetsList.GetCurrent.GetSerialIdList);

            int randomSerialId = PetsList.GetCurrent.AgregarNumeroUnico();
            spawn.GetComponent<PetController>().GetId = randomId;
            spawn.GetComponent<PetController>().GetSerialId = randomSerialId;
            _spawnsList.Add(spawn);
            // Debug.Log(_spawnsList);

            spawn.transform.position = _center + Random.insideUnitSphere * _range;
            spawn.transform.position = new Vector3(spawn.transform.position.x, transform.position.y, spawn.transform.position.z);
        }
    }
int RandomSerialId(List<int> ints)
{
    int id = 0;
    do
    {
        id = (int)Random.Range(0, _maxSpawnsPets);
    } while (ints.Contains(id));
    ints.Add(id);
    return id;
}


    // public void Destroy()
    // {
    //     foreach (GameObject spawn in _spawnsList)
    //     {
    //         Destroy(spawn);
    //     }
    // }
    public void DeleteById(int id){
        _spawnsList.RemoveAt(id);
    }
    public GameObject GetPrefab{set{_prefab = value;}}
    public int GetMaxSpawnerPets{set{_maxSpawnsPets = value;}}
    public Vector3 GetCenter{set{_center = value;}}
    public float GetRange{set{_range = value;}}
    public float GetMinHeight{set{_minHeight = value;}}
    public float GetMaxHeight{set{_maxHeight = value;}}
    public List<GameObject> GetSpawnList{get{return _spawnsList;}}
}

