using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TransportState : BaseState
{
    private List<int> _petsSerialsIds;
    private Vector3 _nextPetPosition;
    private int _actualPetId;
    private EnemieManager _enemieManager;
    private GameObject _actualPet;
    public override void EnterState(EnemieStateMachineManager enemieStateMachineManager)
    {
        PetEventsManager.GetCurrent.onEnemyGoToPet += GotoPet;
    }

    public override void ExitState(EnemieStateMachineManager enemieStateMachineManager)
    {
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Carriage")
        {
            _enemieManager.DropPet();
            PetEventsManager.GetCurrent.EnemyRequestPet();
        }
    }

    public override void UpdateState(EnemieStateMachineManager enemieStateMachineManager)
    {
        _enemieManager = enemieStateMachineManager.GetEnemieManager;
        var _navMeshController = _enemieManager.GetNavMeshController;
        var _isHoldingPet = _enemieManager.GetHoldingPet;
        var _fOV = _enemieManager.GetFieldOfView; 
        //TRANSPORT LOGIC WITH EVENTS
        if (_isHoldingPet)
        {
            //IR HACIA LA CARROZA
            _navMeshController.NavMeshGo();
            _navMeshController.UpdateTargetDir(_enemieManager.GetCarriage.position);

            if(_navMeshController.IsArrived()){
                _enemieManager.DropPet();
                PetEventsManager.GetCurrent.EnemyRequestPet();
            }
            //EN EL TRIGGER ENTER CONTROLLAR QUE SI CHOCA A LA CARROZA O USAR EL IF PARA QUE SUELTE LA CARROZA
        }
        else
        {
            if (_nextPetPosition.Equals(Vector3.zero))
            {
                PetEventsManager.GetCurrent.EnemyRequestPet();
            }
            _navMeshController.UpdateTargetDir(_nextPetPosition);
        }
        //--------------------------()----------------------------
        //CHANGE STATES LOGIC
        if (_fOV.WatchingPlayer && !enemieStateMachineManager.GetEnemieManager.GetPlayerIsHidden)
        {
            Debug.Log("VEO AL JUGADOR(TRANSPORT STATE)");
            enemieStateMachineManager.SwitchState(enemieStateMachineManager.getPersuitState);
        }
        if (_fOV.InRange && !enemieStateMachineManager.GetEnemieManager.GetPlayerIsHidden)
        {
            Debug.Log("EL JUGADOR ESTA CERCA(TRANSPORT STATE)");
            enemieStateMachineManager.SwitchState(enemieStateMachineManager.GetSearchState);
        }
    }

    void GotoPet(GameObject pet, int id)
    {
        _nextPetPosition = pet.transform.position;
        _actualPetId = id;
        _actualPet = pet;
    }

    public override void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Pet")){
            if(other != null){
                PetEventsManager.GetCurrent.DestroyPetById(_actualPetId);
                _enemieManager.GrabPet(_actualPet);
            }
        }
    }
}
