using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarriageStateManager : MonoBehaviour
{
    CarriageBaseState _currentState;
    public CarriageFullState CarriageFullState = new CarriageFullState();
    public CarriageBrokenState CarriageBrokenState = new CarriageBrokenState();
    public CarriageDefaultState CarriageDefaultState = new CarriageDefaultState();

    [SerializeField] private GameObject _petCollected;
    [SerializeField] private GameObject _carriageOpen;
    [SerializeField] private GameObject _carriageClose;
    [Header("Events")]
    [SerializeField] private SimpleEvent _carriageAndEnemy;
    private Transform _spawnPoint;


    void Start()
    {
        _currentState = CarriageDefaultState;
        _currentState.EnterState(this);
        // GetComponent<MeshFilter>().transform.localRotation = Quaternion.Euler(-90, 0, 0);
        //CarriageEventController.GetCurrent.onAddPet += addPet;


    }

    // Update is called once per frame
    void Update()
    {
        _currentState.UpdateState(this);
    }

    public void SwitchState(CarriageBaseState state)
    {
        _currentState = state;
        state.EnterState(this);

    }

    public void OnTriggerEnter(Collider other)
    {
        _currentState.OnTriggerEnter(other);
    }

    //public void addPet(int id)
    //{
    //    GameObject _pet = Instantiate(_petCollected, transform.position, Quaternion.identity, transform);
    //    _pet.GetComponent<PetController>().GetId = id;
    //}
    public GameObject GetOpenCarriage { get { return _carriageOpen; } }
    public GameObject GetCloseCarriage { get { return _carriageClose; } }
    public SimpleEvent GetCarriageAndEnemy {get{return _carriageAndEnemy;}}
}
