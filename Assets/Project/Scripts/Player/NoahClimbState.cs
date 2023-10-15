using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoahClimbState : NoahBaseState
{
    private Vector2 _climbMovement;
    private float _climbSpeed = 2f;
    private bool _jumping = false;
    private bool _finishClimbing = false;
    public override void EnterState(NoahStateMachineManager noahStateMachineManager)
    {
        noahStateMachineManager.GetNoahAnimatorController.IsClimbing(true);
        _jumping = false;
        _finishClimbing = false;
    }

    public override void ExitState(NoahStateMachineManager noahStateMachineManager)
    {
        noahStateMachineManager.GetNoahAnimatorController.IsClimbing(false);
    }

    public override void OnTriggerEnter(Collider other)
    {
    }

    public override void UpdateState(NoahStateMachineManager noahStateMachineManager)
    {
        Debug.Log("Climb State");
        if(PlayerInputManager.getCurrent.getIsJumping){
            noahStateMachineManager.SwitchState(noahStateMachineManager.getJumpState);
        }
        if(noahStateMachineManager.GetNoahController.GetIsFinishClimbing){
            noahStateMachineManager.SwitchState(noahStateMachineManager.getNoahDefaultState);
        }
        Vector2 climbInput = noahStateMachineManager.GetNoahController.GetClimbMovement;
        noahStateMachineManager.GetNoahAnimatorController.ClimbFloats(climbInput.y, climbInput.x);
    }
    // private void Climb(Vector3 input, Rigidbody rb)
    // {
    //     // Rigidbody rb = noahStateMachineManager.GetRigidbody;
    //     Vector3 offset = rb.transform.TransformDirection(Vector2.one * 0.5f);
    //     Vector3 checkDirection = Vector3.zero;
    //     int k = 0;
    //     for (int i = 0; i < 4; i++)
    //     {
    //         RaycastHit checkHit;
    //         if (Physics.Raycast(rb.transform.position + offset,
    //                             rb.transform.forward,
    //                             out checkHit))
    //         {
    //             checkDirection += checkHit.normal;
    //             k++;
    //         }
    //         // Rotate Offset by 90 degrees
    //         offset = Quaternion.AngleAxis(90f, rb.transform.forward) * offset;
    //     }
    //     checkDirection /= k;

    //     RaycastHit hit;
    //     if (Physics.Raycast(rb.transform.position, -checkDirection, out hit))
    //     {
    //         float dot = Vector3.Dot(rb.transform.forward, -hit.normal);

    //         rb.position = Vector3.Lerp(rb.position,
    //                                     hit.point + hit.normal * 0.3f,
    //                                     5f * Time.fixedDeltaTime);
    //         rb.transform.forward = Vector3.Lerp(
    //                                         rb.transform.forward,
    //                                         -hit.normal,
    //                                         10f * Time.fixedDeltaTime
    //                                         );
    //         // rb.useGravity = false;
    //         rb.velocity = rb.transform.TransformDirection(input) * _climbSpeed;
    //         if (PlayerInputManager.getCurrent.getIsJumping)
    //         {
                
    //             _jumping = PlayerInputManager.getCurrent.getIsJumping;
    //         }
    //     }else{
    //         rb.velocity = Vector3.up;
    //         _finishClimbing = true;
    //     }

    // }
}
