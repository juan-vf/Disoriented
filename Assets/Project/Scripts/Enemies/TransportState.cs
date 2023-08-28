using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportState : BaseState
{
    // private EnemieManager _enemieManager;
    // private NavMeshController _navMeshController;
    // private FieldOfView _fOV;
    // private bool _isHoldingPet;

    public override void EnterState(EnemieStateMachineManager enemieStateMachineManager)
    {
        Debug.Log("TRASNPORT STATE");

    }
    public override void ExitState(EnemieStateMachineManager enemieStateMachineManager)
    {
    }
    public override void UpdateState(EnemieStateMachineManager enemieStateMachineManager)
    {
            var _enemieManager = enemieStateMachineManager.GetEnemieManager;
            var _navMeshController = _enemieManager.GetNavMeshController;
            var _isHoldingPet = _enemieManager.GetHoldingPet;
            var _fOV = _enemieManager.GetFieldOfView;
            // TRASPORT PETS LOGIC
            if (_isHoldingPet)
            {
                Debug.Log("Is Holding Pet: " + _isHoldingPet);
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
            if (_navMeshController.IsArrived() && !_isHoldingPet)
            {
                _navMeshController.NavMeshStop();
                _enemieManager.grabPet();
            }
            //--------------------------()----------------------------
            //CHANGE STATES LOGIC
            if (_fOV.WatchingPlayer)
            {
                enemieStateMachineManager.SwitchState(enemieStateMachineManager.getPersuitState);
            }
            if (_fOV.InRange)
            {
                enemieStateMachineManager.SwitchState(enemieStateMachineManager.GetSearchState);
            }
    }

    public override void OnTriggerEnter(Collider other)
    {
    }

}
