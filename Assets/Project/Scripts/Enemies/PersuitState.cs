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
        private float _maxTimeNoSeeingPlayer = 3f;
        private NavMeshController _navMeshController;
        private EnemieAnimatorController _enemieAnimatorController;
        public override void EnterState(EnemieStateMachineManager enemieStateMachineManager)
        {
            _timeNoSeeingPlayer = 0f;
            Debug.Log("persuit state");
            _enemieAnimatorController = enemieStateMachineManager.GetEnemieAnimatorController;
            _navMeshController.SetSpeed(6);
        }
        public override void ExitState(EnemieStateMachineManager enemieStateMachineManager)
        {
            _navMeshController.SetSpeed(5);
        }

        public override void OnCollisionEnter(Collision other)
        {
            //ACA COLLISIONO/ALCANZO AL JUGADOR
            /*
                SE PODRIA LANZAR UN EVENTO PARA QUE EJECUTE LA ANIMACION QUE LOS ATRAPA AL PLAYER
            */
            // if(other.gameObject.CompareTag("Player")){
            //     _enemieAnimatorController.SetIsSearching(true);
            //     _enemieAnimatorController.SetMovement(1);
            //     Debug.Log("ATRAPE AL JUGADOR");
            //     SceneEventController.GetCurrent.LoadLooseScene();
            // }
        }

        public override void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.CompareTag("Player")){
                _enemieAnimatorController.SetIsSearching(true);
                _enemieAnimatorController.SetMovement(1);
                Debug.Log("ATRAPE AL JUGADOR PER");
                SceneEventController.GetCurrent.LoadLooseScene();
            }
        }
        public override void UpdateState(EnemieStateMachineManager enemieStateMachineManager)
        {
            var _navMeshController = enemieStateMachineManager.GetEnemieManager.GetNavMeshController;
            var fOV = enemieStateMachineManager.GetEnemieManager.GetFieldOfView;
            

            if(enemieStateMachineManager.GetEnemieManager.GetPlayerIsHidden && !fOV.InRange){
                Debug.Log("SE ESCONDIO ESTANDO LEJOS DEL RANGO");
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