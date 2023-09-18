using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetSpawner : MonoBehaviour
{
    private static PetSpawner _current;
    [SerializeField]
    private GameObject _petPrefab;
    private int _numberOfPets = 4;
    private int _rangeOfSpawn = 3;
    void Awake() {
        _current = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _numberOfPets; i++)
        {

            // if(){}
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public PetSpawner GetCurrent{get{return _current;}}
}
