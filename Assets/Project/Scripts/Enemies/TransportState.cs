using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportState : BaseState
{
    public override void EnterState(EnemieStateMachineManager enemieStateMachineManager)
    {
        throw new System.NotImplementedException();
    }

    public override void ExitState(EnemieStateMachineManager enemieStateMachineManager)
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerEnter(Collider other)
    {
        throw new System.NotImplementedException();
    }

    // private EnemieManager _enemieManager;
    // private NavMeshController _navMeshController;
    // private FieldOfView _fOV;
    // private bool _isHoldingPet;

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

}
