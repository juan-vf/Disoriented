using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.AI;

public class EnemieManager : MonoBehaviour
{
    public Transform _carriage;
    public Transform _hands;
    [SerializeField]private bool holdingPet = false;
    private NavMeshController _enemieNavMeshController;
    private FieldOfView _fieldOfView;
    private bool _playerIsHidden = false;
    [Header("Events")]
    [SerializeField] private RequestSendLocation _enemyAndSpawner;
    [SerializeField] private GrabEventManager _enemyAndPet;
    [SerializeField] private SimpleEvent _enemyAndCarriage;
    // Start is called before the first frame update
    void Start()
    {
        _enemieNavMeshController = GetComponent<NavMeshController>();
        _fieldOfView = GetComponent<FieldOfView>();

        // ChestEventSystem.current.onDropPet += instanciatePet;
        EnviorementEventsController.GetCurrent.onHiddenPlayer += HiddenUpdates;
        CarriageEventController.GetCurrent.onEnemyLeaves += Leave;
    }

    // Update is called once per frame
    void Update()
    {
    }
    void HiddenUpdates(bool hidden){
        _playerIsHidden = hidden;
    }
    public void GrabPet(){
        // GameObject petIns =  Instantiate(pet, _hands.position, Quaternion.identity, _hands);
        // Rigidbody rb = petIns.GetComponent<Rigidbody>();
        // Destroy(rb);
        holdingPet = true;
    }
    public void DropPet(){
        if(!_hands.GetChild(0).gameObject){return;}
        // CarriageEventController.GetCurrent.AddPet(_hands.GetChild(0).gameObject.GetComponent<PetController>().GetId);
        _enemyAndCarriage.LaunchSimpleEvent();
        Destroy(_hands.GetChild(0).gameObject);
        holdingPet = false;
    }
    void Leave(){
        _enemieNavMeshController.UpdateTargetDir(new Vector3(14.4899998f,-10.8299999f,27.0400009f));
        //ARREGLAR
    }
    public bool GetHoldingPet{get{return holdingPet;} set{ holdingPet = value;}}
    public Transform GetCarriage{get{return _carriage;}}
    public NavMeshController GetNavMeshController{get{return _enemieNavMeshController;}}
    public FieldOfView GetFieldOfView{get{return _fieldOfView;}}
    public bool GetPlayerIsHidden{get{return _playerIsHidden;}}
    public RequestSendLocation GetEnemyAndSpawner{get{return _enemyAndSpawner;}}
    public GrabEventManager GetEnemyAndPet{get{return _enemyAndPet;}}
    public Transform GetHands{get{return _hands;}}
}
