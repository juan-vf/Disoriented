// using System;
using System.Collections;
using System.Collections.Generic;
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
        if(enemieStateMachineManager.GetEnemieManager.GetFieldOfView.WatchingPlayer){
            Debug.Log("VIENDO AL JUGADOR");
            _seen = true;
            //Cambia a el estado PERSAECUCION
        }
        if(_timeSearching > 5f){
            //Cambia a el estado tRANSPORTE O BUSCAR
        }
        _timeSearching += Time.deltaTime;

        if(enemieStateMachineManager.GetEnemieManager.GetNavMeshController.IsArrived()){
            Vector3 point;
            searching(_centerSearchPoint, enemieStateMachineManager.GetEnemieManager.GetFieldOfView.getDistVision,out point);
            enemieStateMachineManager.GetEnemieManager.GetNavMeshController.UpdateTargetDir(point);
        }
    }
    public override void  OnTriggerEnter(Collider other){
        Debug.Log("triger");
    }
    private bool searching(Vector3 center, float range, out Vector3 result){

        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;

        if(NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)){
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
    
}
