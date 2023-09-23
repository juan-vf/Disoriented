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
            
        }
        public override void ExitState(EnemieStateMachineManager enemieStateMachineManager)
        {
        }

        public override void OnCollisionEnter(Collision other)
        {
            throw new NotImplementedException();
        }

        public override void OnTriggerEnter(Collider other)
        {
        }
        public override void UpdateState(EnemieStateMachineManager enemieStateMachineManager)
        {
            var _navMeshController = enemieStateMachineManager.GetEnemieManager.GetNavMeshController;
            var fOV = enemieStateMachineManager.GetEnemieManager.GetFieldOfView;
            _navMeshController.setTarget(fOV.target);
            _navMeshController.PursueTarget();
            if(enemieStateMachineManager.GetEnemieManager.GetPlayerIsHidden){
                enemieStateMachineManager.SwitchState(enemieStateMachineManager.GetSearchState);
            }
            if(!fOV.WatchingPlayer){
                enemieStateMachineManager.SwitchState(enemieStateMachineManager.GetSearchState);
            }
        }
    }
}