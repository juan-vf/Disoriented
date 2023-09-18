using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoahDefaultState : NoahBaseState
{
    private Vector3 _movement;
    //VARIABLES GLOBALES PARA MOSTRAR Y MODIFICAR EN EL EDITOR, PARA TESTEAR
    private float _walkSpeed = 3f;
    float _climbRaycastDistance = 1f;
    public override void EnterState(NoahStateMachineManager noahStateMachineManager)
    {
        Debug.Log("DefaultState");
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
        
        // _movement = new Vector3(PlayerInputManager.getCurrent.getMove.x, 0f, PlayerInputManager.getCurrent.getMove.y);
        // Move(_movement, noahStateMachineManager.GetRigidbody);
        RaycastHit hit;
        // Debug.Log(noahStateMachineManager.GetRigidbody.transform.forward + " " + noahStateMachineManager.transform.forward * .1f);
        if(PlayerInputManager.getCurrent.getIsClimbing && Physics.Raycast(
            noahStateMachineManager.GetRigidbody.transform.position, 
            noahStateMachineManager.GetRigidbody.transform.forward, 
            out hit,
            _climbRaycastDistance
            )){
            noahStateMachineManager.SwitchState(noahStateMachineManager.getNoahClimbState);
        }

        if(PlayerInputManager.getCurrent.getIsJumping){
            noahStateMachineManager.SwitchState(noahStateMachineManager.getJumpState);
        }
        if(PlayerInputManager.getCurrent.getIsCrouched){
            noahStateMachineManager.SwitchState(noahStateMachineManager.getCrouchState);
        }
    }
    // void Move(Vector3 input, Rigidbody _rb){
    //     Vector3 oldVelo = _rb.velocity;
    //     Vector3 newVelo = input * _walkSpeed;
    //     newVelo.y = oldVelo.y;
    //     _rb.velocity = newVelo;
    //     if (input.sqrMagnitude > 0.01f)
    //     {
    //         _rb.transform.forward = input;
    //     }
    //     return;
    // }
}
