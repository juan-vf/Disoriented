using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Disoriented.Assets.Project.Scripts.Enemies
{
    public class PersuitState : BaseState
    {
        private NavMeshController _navMeshController;
        public override void EnterState(EnemieStateMachineManager enemieStateMachineManager)
        {
            Debug.Log("persuit state");
            _navMeshController = enemieStateMachineManager.GetEnemieManager.GetNavMeshController;
        }
        public override void ExitState(EnemieStateMachineManager enemieStateMachineManager)
        {
        }
        public override void OnTriggerEnter(Collider other)
        {
        }
        public override void UpdateState(EnemieStateMachineManager enemieStateMachineManager)
        {
            var fOV = enemieStateMachineManager.GetEnemieManager.GetFieldOfView;
            _navMeshController.PursueTarget();
            if(!fOV.WatchingPlayer){
                enemieStateMachineManager.SwitchState(enemieStateMachineManager.GetSearchState);
            }
        }
    }
}