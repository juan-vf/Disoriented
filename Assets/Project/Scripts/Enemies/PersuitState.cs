using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Disoriented.Assets.Project.Scripts.Enemies
{
    public class PersuitState : BaseState
    {
        private float _timeNoSeeingPlayer;
        private float _maxTimeNoSeeingPlayer = 10f;
        private NavMeshController _navMeshController;
        public override void EnterState(EnemieStateMachineManager enemieStateMachineManager)
        {
            _timeNoSeeingPlayer = 0f;
            Debug.Log("persuit state");
            
        }
        public override void ExitState(EnemieStateMachineManager enemieStateMachineManager)
        {
        }

        public override void OnCollisionEnter(Collision other)
        {
            //ACA COLLISIONO/ALCANZO AL JUGADOR
            /*
                SE PODRIA LANZAR UN EVENTO PARA QUE EJECUTE LA ANIMACION QUE LOS ATRAPA AL PLAYER
            */
            Debug.Log("ATRAPE AL JUGADOR");
        }

        public override void OnTriggerEnter(Collider other)
        {
        }
        public override void UpdateState(EnemieStateMachineManager enemieStateMachineManager)
        {
            var _navMeshController = enemieStateMachineManager.GetEnemieManager.GetNavMeshController;
            var fOV = enemieStateMachineManager.GetEnemieManager.GetFieldOfView;
            

            if(enemieStateMachineManager.GetEnemieManager.GetPlayerIsHidden){
                Debug.Log("SE ESCONDIO");
                //PENSAR LOGICA PARA QUE CUANDO SE ESCONDA Y AUN ESTE CERCA QUE LO AGARRE IGUAL (PUEDE SER DEPENDIENDO LA DISTANCIA, SI HABIA)
                enemieStateMachineManager.SwitchState(enemieStateMachineManager.GetSearchState);
            }
            if(_timeNoSeeingPlayer >= _maxTimeNoSeeingPlayer){
                enemieStateMachineManager.SwitchState(enemieStateMachineManager.GetSearchState);
            }
            if(!fOV.WatchingPlayer){
                _timeNoSeeingPlayer += Time.deltaTime;
            }
            
            //DESIGNA LA POSICION DEL OBJETIVO Y LO PERSIGUE
            _navMeshController.setTarget(fOV.target);
            _navMeshController.PursueTarget();
        }
    }
}