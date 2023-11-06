// using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class SearchState : BaseState
{
    private float _timeSearching;
    private bool _seen;

    private Vector3 _centerSearchPoint;
    private bool _startRutine = true;
    private EnemieAnimatorController _enemieAnimatorController;
    private EnemieStateMachineManager _enemieStateMachineManager;

    //ANIMATIONS
    private float _animationTimer = 0f;
    // private float _animationDuration = 2f;
    private float _searchingAnimationTime = 2f;
    //OTHERS VARIABLES

    public override void EnterState(EnemieStateMachineManager enemieStateMachineManager)
    {
        enemieStateMachineManager.GetEnemieAnimatorController.SetIsSearching(false);
        _timeSearching = 0f;
        _seen = false;
        _centerSearchPoint = enemieStateMachineManager.GetEnemieManager.GetFieldOfView.getTarget.position;
        enemieStateMachineManager.GetEnemieManager.GetNavMeshController.NavMeshStop();
        Vector3 point;
        Searching(out point);
        // Debug.Log(point);
        enemieStateMachineManager.GetEnemieManager.GetNavMeshController.UpdateTargetDir(point);
        //ESCUCHAR(COLISIONA PERO NO LO VE = RAYCAST)
        //LO VE = CAMBIA DE ESTADO PERSECUCION
        _enemieStateMachineManager = enemieStateMachineManager;
        _enemieAnimatorController = enemieStateMachineManager.GetEnemieAnimatorController;
    }

    public override void ExitState(EnemieStateMachineManager enemieStateMachineManager)
    {
        enemieStateMachineManager.GetEnemieAnimatorController.SetIsSearching(false);
        _timeSearching = 0f;
        _seen = false;
        _enemieAnimatorController.SetMovement(1);
    }

    public override void UpdateState(EnemieStateMachineManager enemieStateMachineManager)
    {
        // Debug.Log(enemieStateMachineManager.GetEnemieManager.GetNavMeshController.GetNavMeshAgent.destination);
        //SI EL ENEMIGO LO VE Y EL JUGADOR NO SE ESTA ESCONDIENDO
        if (enemieStateMachineManager.GetEnemieManager.GetFieldOfView.WatchingPlayer && !enemieStateMachineManager.GetEnemieManager.GetPlayerIsHidden)
        {
            // Debug.Log("VIENDO AL JUGADOR");
            _seen = true;
            enemieStateMachineManager.SwitchState(enemieStateMachineManager.getPersuitState);
            //Cambia a el estado PERSAECUCION
        }
        if (_timeSearching > 7f)
        {
            //Cambia a el estado tRANSPORTE O BUSCAR
            _seen = false;
            // _enemieAnimatorController.SetIsSearching(false);
            enemieStateMachineManager.SwitchState(enemieStateMachineManager.getTransportState);
        }
        _timeSearching += Time.deltaTime;


        //SIE EL JUGADOR :ESTA EN EL RANGO, MOVIENDOSE AGACHADO, Y "NO" ESTA ESCONDIDO
        //ACA SE PUEDE DECIRT QUE SI SE MUEVE AGACHADO QUE NO LO DETECTE, YA QUE ESTE CONDICIONAL NO TIENE ENCUENTA SI ESTA AGACHADO
        if (enemieStateMachineManager.GetEnemieManager.GetFieldOfView.InRange && PlayerInputManager.getCurrent.GetIsMovingCrouching && !enemieStateMachineManager.GetEnemieManager.GetPlayerIsHidden)
        {
            enemieStateMachineManager.SwitchState(enemieStateMachineManager.getPersuitState);
            Debug.Log("JUGADOR MOVIENDOCE agachado");
        }

        if (enemieStateMachineManager.GetEnemieManager.GetNavMeshController.IsArrived())
        {
            // Debug.Log("LLEGO AL PUNTO EN BUSQUEDA");
            _enemieAnimatorController.SetIsTransporting(false);
            _enemieAnimatorController.SetIsSearching(true);
            _enemieAnimatorController.SetMovement(0);
            _animationTimer += Time.deltaTime;

            if (_animationTimer > _searchingAnimationTime)
            {
                
                Vector3 point;
                Searching(out point);
                _enemieStateMachineManager.GetEnemieManager.GetNavMeshController.UpdateTargetDir(point);
                _enemieAnimatorController.SetIsSearching(false);
                _enemieAnimatorController.SetIsTransporting(false);
                _enemieStateMachineManager.GetEnemieManager.GetNavMeshController.SetAgentValues("4", "100", "4", "0");
                _animationTimer = 0f;
            }
        }
    }
        private void OnDrawGizmos()
    {
        // Obtiene el centro de la esfera.
        Vector3 center = _centerSearchPoint;

        // Genera un punto aleatorio dentro de la esfera.
        Vector3 point = Random.insideUnitSphere * 4;
        Gizmos.color = Color.blue;

        // Dibuja un círculo en el punto aleatorio.
        Gizmos.DrawSphere(center + point, 4);
    }
    public override void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && _enemieStateMachineManager.GetEnemieManager.GetPlayerIsHidden == false){
                _enemieAnimatorController.SetIsSearching(true);
                _enemieAnimatorController.SetMovement(1);
                Debug.Log("ATRAPE AL JUGADOR SEARCH");
                SceneEventController.GetCurrent.LoadLooseScene();
        }
    }
    private bool Searching(out Vector3 result)
    {
        Vector3 center = _centerSearchPoint;
        Vector3 randomPoint;
        NavMeshHit hit;
        do
        {
            randomPoint = center + Random.insideUnitSphere * 4;
        } while (!NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas));
        result = randomPoint;
        return true;
    }

    public override void OnCollisionEnter(Collision other)
    {
        // throw new System.NotImplementedException();
    }
    
}
