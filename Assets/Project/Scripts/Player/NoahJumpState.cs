using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoahJumpState : NoahBaseState
{
    private float _jumpSpeed = 3f;
    private float _jumpCount = 0f;
    private float _maxRayDistanceToClimb = 1f;
    public override void EnterState(NoahStateMachineManager noahStateMachineManager)
    {
    }

    public override void ExitState(NoahStateMachineManager noahStateMachineManager)
    {
    }

    public override void OnTriggerEnter(Collider other)
    {
    }

    public override void UpdateState(NoahStateMachineManager noahStateMachineManager)
    {
        Debug.Log("NoahJumpState");
        RaycastHit hit;
        // if (Physics.Raycast(
        //                     noahStateMachineManager.GetRigidbody.transform.position,
        //                     Vector3.down,
        //                     out hit,
        //                     1f
        //                     )
        //     )
        // {
        //     noahStateMachineManager.SwitchState(noahStateMachineManager.getNoahDefaultState);
        // }
        Jump(noahStateMachineManager.GetRigidbody);
        if (PlayerInputManager.getCurrent.getIsClimbing && Physics.Raycast(
            noahStateMachineManager.GetRigidbody.transform.position,
            noahStateMachineManager.GetRigidbody.transform.forward,
            out hit,
            _maxRayDistanceToClimb
            ))
        {
            Debug.Log("Para trepar");
            noahStateMachineManager.SwitchState(noahStateMachineManager.getNoahClimbState);
        }
        else
        {
            noahStateMachineManager.SwitchState(noahStateMachineManager.getNoahDefaultState);
        }
    }
    void Jump(Rigidbody rb)
    {
        rb.velocity = Vector3.up * _jumpSpeed;
        // rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
    }
}
