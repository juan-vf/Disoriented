using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportState : BaseState
{
    private List<int> _petsSerialsIds;
    private Vector3 _nextPetPosition;
    public override void EnterState(EnemieStateMachineManager enemieStateMachineManager)
    {
        PetEventsManager.GetCurrent.onEnemyGoToPet += GotoPet;
    }

    public override void ExitState(EnemieStateMachineManager enemieStateMachineManager)
    {
    }

    public override void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Carriage"){
            //LANZAR EVENTO ENEMYREQUEST
            Debug.Log("LLEGO A LA CARROZA");
        }
    }

    public override void UpdateState(EnemieStateMachineManager enemieStateMachineManager)
    {
        var _enemieManager = enemieStateMachineManager.GetEnemieManager;
        var _navMeshController = _enemieManager.GetNavMeshController;
        var _isHoldingPet = _enemieManager.GetHoldingPet;
        var _fOV = _enemieManager.GetFieldOfView;
        // TRASPORT PETS LOGIC
        /*
        if (_isHoldingPet)
        {
            // Debug.Log("Is Holding Pet: " + _isHoldingPet);
            _navMeshController.NavMeshGo();
            _navMeshController.UpdateTargetDir(_enemieManager.GetPointB.position);

            if (_navMeshController.IsArrived())
            {
                _enemieManager.dropPet();
            }
        }
        else
        {
            _navMeshController.UpdateTargetDir(_enemieManager.GetPointA.position);
        }
        */
        /*
        if (_navMeshController.IsArrived() && !_isHoldingPet)
        {
            _navMeshController.NavMeshStop();
            _enemieManager.grabPet();
        }
        */

        //NEW TRANSPORT LOGIC WITH EVENTS
        if(_isHoldingPet){
            //IR HACIA LA CARROZA
            _navMeshController.NavMeshGo();
            _navMeshController.UpdateTargetDir(_enemieManager.GetCarriage.position);
            //EN EL TRIGGER ENTER CONTROLLAR QUE SI CHOCA A LA CARROZA O USAR EL IF PARA QUE SUELTE LA CARROZA
            /*if (_navMeshController.IsArrived())
            {
                _enemieManager.dropPet();
                //LANZAR EVENTO ENEMYREQUEST
            }*/

        }else{
            _navMeshController.UpdateTargetDir(_nextPetPosition);
        }
        //--------------------------()----------------------------
        //CHANGE STATES LOGIC
        if (_fOV.WatchingPlayer && !enemieStateMachineManager.GetEnemieManager.GetPlayerIsHidden)
        {
            enemieStateMachineManager.SwitchState(enemieStateMachineManager.getPersuitState);
        }
        if (_fOV.InRange && !enemieStateMachineManager.GetEnemieManager.GetPlayerIsHidden)
        {
            enemieStateMachineManager.SwitchState(enemieStateMachineManager.GetSearchState);
        }
    }

    void UpdatePetsSerialsIdList(List<GameObject> pets){
        foreach (var pet in pets)
        {
            _petsSerialsIds.Add(pet.GetComponent<PetController>().GetSerialId);
        }
    }
    void GotoPet(Vector3 petPosition){
        _nextPetPosition = petPosition;
    }

}
