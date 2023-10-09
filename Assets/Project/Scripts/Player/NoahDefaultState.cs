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
        Debug.Log("DefaultState");
        RaycastHit hit;
        if (PlayerInputManager.getCurrent.getIsClimbing && Physics.Raycast(
            noahStateMachineManager.GetRigidbody.transform.position,
            noahStateMachineManager.GetRigidbody.transform.forward,
            out hit,
            _climbRaycastDistance
            ))
        {
            Debug.Log("Preparado para escalar");
            noahStateMachineManager.SwitchState(noahStateMachineManager.getNoahClimbState);
        }

        RaycastHit hitJump;
        if (PlayerInputManager.getCurrent.getIsJumping && Physics.Raycast(noahStateMachineManager.GetRigidbody.transform.position,
                        Vector3.down,
                        out hitJump,
                        .05f
                        ))
        {
            noahStateMachineManager.SwitchState(noahStateMachineManager.getJumpState);
        }
        if (PlayerInputManager.getCurrent.getIsCrouched)
        {
            noahStateMachineManager.SwitchState(noahStateMachineManager.getCrouchState);
        }
    }
}
