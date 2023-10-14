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
        Jump(noahStateMachineManager.GetRigidbody);
        noahStateMachineManager.GetNoahAnimatorController.OnGround(true);
    }

    public override void ExitState(NoahStateMachineManager noahStateMachineManager)
    {
        noahStateMachineManager.GetNoahAnimatorController.OnGround(true);
    }

    public override void OnTriggerEnter(Collider other)
    {
    }

    public override void UpdateState(NoahStateMachineManager noahStateMachineManager)
    {
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
            noahStateMachineManager.SwitchState(noahStateMachineManager.getNoahDefaultState);
        }
        noahStateMachineManager.GetNoahAnimatorController.JumpVelocity(noahStateMachineManager.GetRigidbody.velocity.y * 0.1f);

    }
    void Jump(Rigidbody rb)
    {
        rb.velocity = Vector3.up * _jumpSpeed;
    }
}
