using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TransportState : BaseState
{
    private List<int> _petsSerialsIds;
    private Vector3 _nextPetPosition = Vector3.zero;
    private Vector3 _oldPetPosition;
    private int _actualPetId;
    private EnemieManager _enemieManager;
    private GameObject _actualPet;
    private EnemieStateMachineManager _enemieStateMachineManager;
    private NavMeshController _navMeshController;
    private bool _isHoldingPet = false;
    public override void EnterState(EnemieStateMachineManager enemieStateMachineManager)
    {
        _enemieStateMachineManager = enemieStateMachineManager;
        enemieStateMachineManager.GetEnemieAnimatorController.SetIsTransporting(true);
        enemieStateMachineManager.GetEnemieAnimatorController.SetIsSearching(false);
        // _navMeshController = enemieStateMachineManager.GetEnemieManager.GetNavMeshController;
        // PetEventsManager.GetCurrent.onEnemyGoToPet += GotoPet;
        // enemieStateMachineManager.GetEnemieManager.GetNavMeshController.SetSpeed(7);
        // enemieStateMachineManager.GetEnemieManager.GetNavMeshController.SetAgentValues("7", "200", "7", "6");

        enemieStateMachineManager.GetEnemieManager.GetEnemyAndSpawner.onSendLocation += GotoPet;
    }

    public override void ExitState(EnemieStateMachineManager enemieStateMachineManager)
    {
    }

    public override void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Carriage")
        {
            _enemieStateMachineManager.GetEnemieAnimatorController.SetMovement(-1);
            _enemieManager.DropPet();
            _enemieStateMachineManager.GetEnemieManager.GetEnemyAndSpawner.RequestLocation();
            // _enemieManager.DropPet();
            // PetEventsManager.GetCurrent.EnemyRequestPet();
        }
        if (other.gameObject.CompareTag("Pet"))
        {
            // Debug.Log("CHOCANDO CON MASCOTA");
            if (other.transform.GetComponent<PetController>().GetSerialId == _actualPetId)
            {
                // PetEventsManager.GetCurrent.DestroyPetById(_actualPetId);
                _enemieManager.GetEnemyAndPet.GrabPetInHand(_actualPetId, _enemieManager.GetHands);
                // Debug.Log("Mascota a destruir: " + _actualPetId + "mascota encontrada: " + other.transform.GetComponent<PetController>().GetSerialId);
                _enemieManager.GetHoldingPet = true;
            }
        }
        if (other.gameObject.CompareTag("Player") && !_enemieStateMachineManager.GetEnemieManager.GetPlayerIsHidden)
        {
            _enemieStateMachineManager.GetEnemieAnimatorController.SetIsSearching(true);
            _enemieStateMachineManager.GetEnemieAnimatorController.SetMovement(1);
            Debug.Log("ATRAPE AL JUGADOR TRANS");
            SceneEventController.GetCurrent.LoadLooseScene();
        }
    }

    public override void UpdateState(EnemieStateMachineManager enemieStateMachineManager)
    {


        _enemieManager = enemieStateMachineManager.GetEnemieManager;
        _navMeshController = _enemieManager.GetNavMeshController;
        _isHoldingPet = enemieStateMachineManager.GetEnemieManager.GetHoldingPet;
        var _fOV = enemieStateMachineManager.GetEnemieManager.GetFieldOfView;


        //TRANSPORT LOGIC WITH EVENTS
        if (_isHoldingPet)
        {

            //ANIMACION DE CAMINATA LLEVANDO LA MASCOTA
            enemieStateMachineManager.GetEnemieAnimatorController.SetIsTransporting(true);
            enemieStateMachineManager.GetEnemieAnimatorController.SetMovement(1);
            //IR HACIA LA CARROZA
            _navMeshController.NavMeshGo();
            _navMeshController.UpdateTargetDir(_enemieManager.GetCarriage.position);
            // Debug.Log("LLENDO A DEJAR A LA MASCOTA A LA CARROZA");
            _navMeshController.SetStoppingDistance(1f);

            // if (_navMeshController.IsArrived())
            // {
            //     //SI LA TENGO Y LLEGUE LA SUELTO
            //     enemieStateMachineManager.GetEnemieAnimatorController.SetMovement(-1);
            //     _enemieManager.DropPet();
            //     enemieStateMachineManager.GetEnemieManager.GetEnemyAndSpawner.RequestLocation();
            //     Debug.Log("LA DEJO EN LA CARROZA y solicito otra");
            // }
            //EN EL TRIGGER ENTER CONTROLLAR QUE SI CHOCA A LA CARROZA O USAR EL IF PARA QUE SUELTE LA CARROZA
        }
        else
        {
            _navMeshController.SetStoppingDistance(2f);
            //ANIMACION DE CAMINATA NORMAL
            enemieStateMachineManager.GetEnemieAnimatorController.SetIsSearching(false);
            enemieStateMachineManager.GetEnemieAnimatorController.SetIsTransporting(false);
            enemieStateMachineManager.GetEnemieAnimatorController.SetMovement(0);
            _navMeshController.UpdateTargetDir(_nextPetPosition);
            if (_nextPetPosition == Vector3.zero) { enemieStateMachineManager.GetEnemieManager.GetEnemyAndSpawner.RequestLocation(); }
            // if (_navMeshController.IsArrived())

            // {
            //ARREGLAR: EL ENEMIGO RECIBE UNA UBICAICON PARA IR A BUSCAR A LA MASCOTA, PERO EL NOAH YA LA AGARRO, ENTONCES DEBERIA PEDIR OTRA
            // Debug.Log("BUSCANDO UNA MASCOTA");
            // PetEventsManager.GetCurrent.EnemyRequestPet();
            // enemieStateMachineManager.GetEnemieManager.GetEnemyAndSpawner.RequestLocation();
            // }
        }
        //--------------------------()----------------------------
        //CHANGE STATES LOGIC
        if (_fOV.WatchingPlayer && !enemieStateMachineManager.GetEnemieManager.GetPlayerIsHidden)
        {
            Debug.Log("VEO AL JUGADOR(TRANSPORT STATE)");
            enemieStateMachineManager.SwitchState(enemieStateMachineManager.getPersuitState);
        }
        if (_fOV.InRange && enemieStateMachineManager.GetEnemieManager.GetPlayerIsHidden == false)
        {
            Debug.Log("EL JUGADOR ESTA CERCA(TRANSPORT STATE)");
            enemieStateMachineManager.SwitchState(enemieStateMachineManager.GetSearchState);
        }
    }

    void GotoPet(GameObject pet)
    {
        if (pet != null)
        {
            _nextPetPosition = pet.transform.position;
            _oldPetPosition = _nextPetPosition;
            _actualPetId = pet.transform.GetComponent<PetController>().GetSerialId;
            _actualPet = pet;
            // Debug.Log(_actualPetId);
        }

    }
    public override void OnCollisionEnter(Collision other)
    {
        // if (other.gameObject.CompareTag("Pet"))
        // {
        //     // Debug.Log("CHOCANDO CON MASCOTA");
        //     if (other.transform.GetComponent<PetController>().GetSerialId == _actualPetId)
        //     {
        //         // PetEventsManager.GetCurrent.DestroyPetById(_actualPetId);
        //         _enemieManager.GetEnemyAndPet.GrabPetInHand(_actualPetId, _enemieManager.GetHands);
        //         Debug.Log("Mascota a destruir: " + _actualPetId + "mascota encontrada: " + other.transform.GetComponent<PetController>().GetSerialId);
        //         _enemieManager.GetHoldingPet = true;
        //     }
        // }
    }
}
