using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SearchState : BaseState
{
    private float _timeSearching;
    private bool _seen;

    public override void EnterState(EnemieStateMachineManager enemieStateMachineManager)
    {
        _timeSearching = 0f;
        _seen = false;
        Debug.Log("Buscando" + !_seen + _seen);
        //BUSCAR = POR UN TIEMPO Y MOVERSE POR DONDE LO VIO POR ULTIMA VEZ O POR DONDE ESCUCHA
        //ESCUCHAR(COLISIONA PERO NO LO VE = RAYCAST)
        //LO VE = CAMBIA DE ESTADO PERSECUCION
    }

    public override void ExitState(EnemieStateMachineManager enemieStateMachineManager)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(EnemieStateMachineManager enemieStateMachineManager)
    {
        if(_seen){
            _timeSearching += Time.deltaTime;
        }
        if(!_seen){
            //Cambia a el estado persecucion
            enemieStateMachineManager.SwitchState(enemieStateMachineManager.getCurrentState);
        }
        if(_timeSearching > 5f){
            //Cambia a el estado por defecto
        }
    }
    public override void  OnTriggerEnter(Collider other){
        Debug.Log("triger");
    }
    
}
