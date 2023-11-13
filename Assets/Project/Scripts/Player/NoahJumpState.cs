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
        // Debug.Log("ENTER SALTO");
        noahStateMachineManager.GetNoahController.SetJumpCollider();
        noahStateMachineManager.GetNoahAnimatorController.Jump(true);
        Jump(noahStateMachineManager.GetRigidbody);
        noahStateMachineManager.GetNoahAnimatorController.OnGround(false);
    }

    public override void ExitState(NoahStateMachineManager noahStateMachineManager)
    {
        noahStateMachineManager.GetNoahAnimatorController.Jump(false);
    }

    public override void OnTriggerEnter(Collider other)
    {
    }

    public override void UpdateState(NoahStateMachineManager noahStateMachineManager)
    {
        // Debug.Log("NoahJumpState");
        if (noahStateMachineManager.GetNoahController.GetOnGround)
        {
            // Debug.Log("En el suelo");
            noahStateMachineManager.GetNoahController.EnaDisaColliders("jump", false);
            noahStateMachineManager.SwitchState(noahStateMachineManager.getNoahDefaultState);
        }
        noahStateMachineManager.GetNoahAnimatorController.JumpVelocity(noahStateMachineManager.GetRigidbody.velocity.y * 0.1f);

    }
    void Jump(Rigidbody rb)
    {
        rb.velocity = Vector3.up * _jumpSpeed;
    }
}
