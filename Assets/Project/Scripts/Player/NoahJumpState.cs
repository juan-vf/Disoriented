using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoahJumpState : NoahBaseState
{
    private float _jumpSpeed = 5f;
    private float _jumpCount = 0f;
    private float _maxRayDistanceToClimb = 1f;
    private float _countToJumpAnimation;
    public override void EnterState(NoahStateMachineManager noahStateMachineManager)
    {
        noahStateMachineManager.GetNoahAnimatorController.UpdateJumpBool(true);
        noahStateMachineManager.GetNoahAnimatorController.EndJump(false);
        Jump(noahStateMachineManager.GetRigidbody);
    }

    public override void ExitState(NoahStateMachineManager noahStateMachineManager)
    {
        noahStateMachineManager.GetNoahAnimatorController.UpdateJumpBool(false);
        noahStateMachineManager.GetNoahAnimatorController.EndJump(true);
    }

    public override void OnTriggerEnter(Collider other)
    {
    }

    public override void UpdateState(NoahStateMachineManager noahStateMachineManager)
    {
        Vector3 origin = noahStateMachineManager.GetRigidbody.transform.position;

        // Obtiene el punto final del rayo.
        Vector3 end = origin + Vector3.down * .1f;

        // Dibuja el rayo.
        Debug.DrawRay(origin, end, Color.green);
        Debug.Log("NoahJumpState");
        RaycastHit hit;
        if (Physics.Raycast(
                            noahStateMachineManager.GetRigidbody.transform.position,
                            Vector3.down,
                            out hit,
                            .05f
                            )
            )
        {
            Debug.Log("ME VOY DE JUMP");
            // noahStateMachineManager.SwitchState(noahStateMachineManager.getNoahDefaultState);
        }
        if((Vector3.one * .05f).y > noahStateMachineManager.GetRigidbody.transform.position.y){
            noahStateMachineManager.SwitchState(noahStateMachineManager.getNoahDefaultState);
        }
        // Jump(noahStateMachineManager.GetRigidbody);
        // if (PlayerInputManager.getCurrent.getIsClimbing && Physics.Raycast(
        //     noahStateMachineManager.GetRigidbody.transform.position,
        //     noahStateMachineManager.GetRigidbody.transform.forward,
        //     out hit,
        //     _maxRayDistanceToClimb
        //     ))
        // {
        //     Debug.Log("Para trepar");
        //     noahStateMachineManager.SwitchState(noahStateMachineManager.getNoahClimbState);
        // }
        // else
        // {
        //     noahStateMachineManager.SwitchState(noahStateMachineManager.getNoahDefaultState);
        // }
        // if(_countToJumpAnimation > .5f){
        //     _countToJumpAnimation = 0f;
        //     noahStateMachineManager.SwitchState(noahStateMachineManager.getNoahDefaultState);
        // }
        // _countToJumpAnimation += Time.deltaTime;

        
    }
    void Jump(Rigidbody rb)
    {
        rb.velocity = Vector3.up * _jumpSpeed;
        // rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
    }
}
