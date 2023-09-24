// using System;
using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class SearchState : BaseState
{
    private float _timeSearching;
    private bool _seen;

    private Vector3 _centerSearchPoint;

    public override void EnterState(EnemieStateMachineManager enemieStateMachineManager)
    {
        _timeSearching = 0f;
        _seen = false;
        _centerSearchPoint = enemieStateMachineManager.GetEnemieManager.GetFieldOfView.getTarget.position;
        enemieStateMachineManager.GetEnemieManager.GetNavMeshController.NavMeshStop();
        Vector3 point;
        searching(_centerSearchPoint, enemieStateMachineManager.GetEnemieManager.GetFieldOfView.getDistVision,out point);
        Debug.Log(point);
        enemieStateMachineManager.GetEnemieManager.GetNavMeshController.UpdateTargetDir(point);
        //ESCUCHAR(COLISIONA PERO NO LO VE = RAYCAST)
        //LO VE = CAMBIA DE ESTADO PERSECUCION
    }

    public override void ExitState(EnemieStateMachineManager enemieStateMachineManager)
    {
        _timeSearching = 0f;
        _seen = false;
    }

    public override void UpdateState(EnemieStateMachineManager enemieStateMachineManager)
    {
        Debug.Log(enemieStateMachineManager.GetEnemieManager.GetNavMeshController.GetNavMeshAgent.destination);
        //SI EL ENEMIGO LO VE Y EL JUGADOR NO SE ESTA ESCONDIENDO
        if(enemieStateMachineManager.GetEnemieManager.GetFieldOfView.WatchingPlayer && !enemieStateMachineManager.GetEnemieManager.GetPlayerIsHidden){
            Debug.Log("VIENDO AL JUGADOR");
            _seen = true;
            enemieStateMachineManager.SwitchState(enemieStateMachineManager.getPersuitState);
            //Cambia a el estado PERSAECUCION
        }
        if(_timeSearching > 20f){
            //Cambia a el estado tRANSPORTE O BUSCAR
            _seen = false;
            enemieStateMachineManager.SwitchState(enemieStateMachineManager.getTransportState);
        }
        _timeSearching += Time.deltaTime;

        
        if(enemieStateMachineManager.GetEnemieManager.GetNavMeshController.IsArrived()){
            Debug.Log("LLEGO AL PUNTO EN BUSQUEDA");
            Vector3 point;
            searching(_centerSearchPoint, enemieStateMachineManager.GetEnemieManager.GetFieldOfView.getDistVision,out point);
            enemieStateMachineManager.GetEnemieManager.GetNavMeshController.UpdateTargetDir(point);
        }
    }
    public override void  OnTriggerEnter(Collider other){
        Debug.Log("triger");
    }
    private bool searching(Vector3 center, float range, out Vector3 result){

        // Vector3 randomPoint = center + Random.insideUnitSphere * 2;
        // NavMeshHit hit;
        Vector3 randomPoint;
        NavMeshHit hit;
        do
        {
            randomPoint = center + Random.insideUnitSphere * 5;
        } while (!NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas));

        // if(NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)){
        //     result = hit.position;
        //     return true;
        // }
        result = randomPoint;
        return true;
    }

    public override void OnCollisionEnter(Collision other)
    {
        throw new System.NotImplementedException();
    }
}
