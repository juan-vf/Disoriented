using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoahClimbState : NoahBaseState
{
    private Vector2 _climbMovement;
    private float _climbSpeed = 3f;
    public override void EnterState(NoahStateMachineManager noahStateMachineManager)
    {
        // noahStateMachineManager.GetRigidbody.useGravity = false;
        Debug.Log("ClimbState");
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
        _climbMovement = new Vector2(PlayerInputManager.getCurrent.getMove.x, PlayerInputManager.getCurrent.getMove.y).normalized;
        // noahStateMachineManager.GetRigidbody.useGravity = false;
        Climb(_climbMovement, noahStateMachineManager.GetRigidbody);
    }
    private void Climb(Vector3 input, Rigidbody rb)
    {
        Vector3 offset = rb.transform.TransformDirection(Vector2.one * 0.5f);
        Vector3 checkDirection = Vector3.zero;
        int k = 0;
        for (int i = 0; i < 4; i++)
        {
            RaycastHit checkHit;
            if (Physics.Raycast(rb.transform.position + offset,
                                rb.transform.forward,
                                out checkHit))
            {
                checkDirection += checkHit.normal;
                k++;
            }
            // Rotate Offset by 90 degrees
            offset = Quaternion.AngleAxis(90f, rb.transform.forward) * offset;
        }
        checkDirection /= k;

        RaycastHit hit;
        if (Physics.Raycast(rb.transform.position, -checkDirection, out hit))
        {
            float dot = Vector3.Dot(rb.transform.forward, -hit.normal);

            rb.position = Vector3.Lerp(rb.position,
                                        hit.point + hit.normal * 0.3f,
                                        5f * Time.fixedDeltaTime);
            rb.transform.forward = Vector3.Lerp(rb.transform.forward,
                                            -hit.normal,
                                            10f * Time.fixedDeltaTime);
            // rb.useGravity = false;
            rb.velocity = rb.transform.TransformDirection(input) * _climbSpeed;
            // if (jumpDown)
            // {
            //     rb.velocity = Vector3.up * 5f + hit.normal * 2f;
            //     state = PlayerState.FALLING;
            // }
        }

    }
}
