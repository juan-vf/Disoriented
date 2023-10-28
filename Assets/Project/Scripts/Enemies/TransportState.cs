using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TransportState : BaseState
{
    private List<int> _petsSerialsIds;
    private Vector3 _nextPetPosition;
    private Vector3 _oldPetPosition;
    private int _actualPetId;
    private EnemieManager _enemieManager;
    private GameObject _actualPet;
    public override void EnterState(EnemieStateMachineManager enemieStateMachineManager)
    {
        enemieStateMachineManager.GetEnemieAnimatorController.SetIsSearching(false);
        PetEventsManager.GetCurrent.onEnemyGoToPet += GotoPet;
        // enemieStateMachineManager.GetEnemieManager.GetNavMeshController.SetSpeed(7);
        enemieStateMachineManager.GetEnemieManager.GetNavMeshController.SetAgentValues("7", "200", "7", "6");
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

            //ANIMACION DE CAMINATA LLEVANDO LA MASCOTA
            enemieStateMachineManager.GetEnemieAnimatorController.SetIsTransporting(true);
            enemieStateMachineManager.GetEnemieAnimatorController.SetMovement(1);
            //IR HACIA LA CARROZA
            _navMeshController.NavMeshGo();
            _navMeshController.UpdateTargetDir(_enemieManager.GetCarriage.position);
            Debug.Log("LLENDO A DEJAR A LA MASCOTA A LA CARROZA");
            _navMeshController.SetStoppingDistance(6f);

            if (_navMeshController.IsArrived())
            {
                //SI LA TENGO Y LLEGUE LA SUELTO
                enemieStateMachineManager.GetEnemieAnimatorController.SetMovement(-1);
                // if (enemieStateMachineManager.GetEnemieAnimatorController.GetAnimationLengthByName("FauniscorTakingPet") == enemieStateMachineManager.GetEnemieAnimatorController.GetAnimator.GetCurrentAnimatorStateInfo(0).length)
                // {
                    _enemieManager.DropPet();
                    PetEventsManager.GetCurrent.EnemyRequestPet();
                    Debug.Log("LA DEJO EN LA CARROZA");
                // }
            }
            //EN EL TRIGGER ENTER CONTROLLAR QUE SI CHOCA A LA CARROZA O USAR EL IF PARA QUE SUELTE LA CARROZA
        }
        else
        {
            _navMeshController.SetStoppingDistance(2f);
            //ANIMACION DE CAMINATA NORMAL
            enemieStateMachineManager.GetEnemieAnimatorController.SetIsTransporting(false);
            enemieStateMachineManager.GetEnemieAnimatorController.SetMovement(0);
            _navMeshController.UpdateTargetDir(_nextPetPosition);
            if (_nextPetPosition.Equals(Vector3.zero))
            {
                //ARREGLAR: EL ENEMIGO RECIBE UNA UBICAICON PARA IR A BUSCAR A LA MASCOTA, PERO EL NOAH YA LA AGARRO, ENTONCES DEBERIA PEDIR OTRA
                Debug.Log("BUSCANDO UNA MASCOTA");
                PetEventsManager.GetCurrent.EnemyRequestPet();
            }
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
        _oldPetPosition = _nextPetPosition;
        _actualPetId = id;
        _actualPet = pet;
    }

    public override void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Pet"))
        {
            // Debug.Log("CHOCANDO CON MASCOTA");
            if (other.transform.GetComponent<PetController>().GetSerialId != _actualPetId)
            {
                PetEventsManager.GetCurrent.DestroyPetById(_actualPetId);
                Debug.Log("Mascota a destruir: "+_actualPetId + "mascota encontrada: "+other.transform.GetComponent<PetController>().GetSerialId);
                _enemieManager.GrabPet(_actualPet);
            }
        }
    }
}
