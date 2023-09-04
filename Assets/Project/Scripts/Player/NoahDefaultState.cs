using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoahDefaultState : NoahBaseState
{
    private Vector3 _movement;
    //VARIABLES GLOBALES PARA MOSTRAR Y MODIFICAR EN EL EDITOR, PARA TESTEAR
    private float _walkSpeed = 3f;
    float _maxRayDistanceToClimb = 1f;
    public override void EnterState(NoahStateMachineManager noahStateMachineManager)
    {
        // throw new System.NotImplementedException();
    }

    public override void ExitState(NoahStateMachineManager noahStateMachineManager)
    {
        // throw new System.NotImplementedException();
    }

    public override void OnTriggerEnter(Collider other)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(NoahStateMachineManager noahStateMachineManager)
    {
        
        _movement = new Vector3(PlayerInputManager.getCurrent.getMove.x, 0f, PlayerInputManager.getCurrent.getMove.y);
        Move(_movement, noahStateMachineManager.GetRigidbody);
        /*
            PARA CAMBIAR DE ESTADOS
            -APRETA LA E, LANZA UN RAYO Y SI CHOCA CAMBIA A CLIMBSTATE
            -SI SALTA ESTADO JUMPSTATE
        */
        RaycastHit hit;
        Debug.Log(noahStateMachineManager.GetRigidbody.transform.forward + " " + noahStateMachineManager.transform.forward * .1f);
        if(PlayerInputManager.getCurrent.getIsClimbing && Physics.Raycast(
            noahStateMachineManager.GetRigidbody.transform.position, 
            noahStateMachineManager.GetRigidbody.transform.forward, 
            _maxRayDistanceToClimb
            )){
            Debug.Log("Para trepar");
            noahStateMachineManager.SwitchState(noahStateMachineManager.getNoahClimbState);
        }
    }
    void Move(Vector3 input, Rigidbody _rb){
        Vector3 oldVelo = _rb.velocity;
        Vector3 newVelo = input * _walkSpeed;
        newVelo.y = oldVelo.y;
        _rb.velocity = newVelo;
        if (input.sqrMagnitude > 0.01f)
        {
            _rb.transform.forward = input;
        }
    }
}
