using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemieManager : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    public Transform _hands;

    private bool holdingPet = false;
    private NavMeshController _enemieNavMeshController;
    private FieldOfView _fieldOfView;
    private bool _playerIsHidden;
    // Start is called before the first frame update
    void Start()
    {
        _enemieNavMeshController = GetComponent<NavMeshController>();
        _fieldOfView = GetComponent<FieldOfView>();

        ChestEventSystem.current.onDropPet += instanciatePet;
        EnviorementEventsController.GetCurrent.onHiddenPlayer += HiddenUpdates;
    }

    // Update is called once per frame
    void Update()
    {
    }
    void HiddenUpdates(bool hidden){
        _playerIsHidden = hidden;
    }
    public void grabPet(){
        holdingPet = true;
        ChestEventSystem.current.GrabPet();
        Debug.Log("agarra mascota");
    }
    private void instanciatePet(GameObject prefab){
        GameObject var =  Instantiate(prefab, _hands.position, Quaternion.identity, transform);
        Destroy(var, 5);
    }
    public void dropPet(){
        holdingPet = false;
        Debug.Log("suelta mascota");
    }
    public bool GetHoldingPet{get{return holdingPet;}}
    public Transform GetPointA{get{return pointA;}}
    public Transform GetPointB{get{return pointB;}}
    public NavMeshController GetNavMeshController{get{return _enemieNavMeshController;}}
    public FieldOfView GetFieldOfView{get{return _fieldOfView;}}
    public bool GetPlayerIsHidden{get{return _playerIsHidden;}}
}
