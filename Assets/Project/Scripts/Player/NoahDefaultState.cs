using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoahDefaultState : NoahBaseState
{
    private Vector3 _movement;
    //VARIABLES GLOBALES PARA MOSTRAR Y MODIFICAR EN EL EDITOR, PARA TESTEAR
    private float _walkSpeed = 3f;
    float _climbRaycastDistance = .5f;
    public override void EnterState(NoahStateMachineManager noahStateMachineManager)
    {
        noahStateMachineManager.GetNoahController.SetStandingCollider();
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
        RaycastHit wallPoint;
        
        if (PlayerInputManager.getCurrent.getIsClimbing && Physics.Raycast(
            noahStateMachineManager.GetRigidbody.transform.position + noahStateMachineManager.GetRigidbody.transform.TransformDirection(Vector2.up * 0.5f),
            noahStateMachineManager.GetRigidbody.transform.forward,
            out wallPoint,
            1.3f))
        {
            Debug.Log("Preparado para escalar");
            noahStateMachineManager.SwitchState(noahStateMachineManager.getNoahClimbState);
        }

        if (PlayerInputManager.getCurrent.getIsJumping && noahStateMachineManager.GetNoahController.GetOnGround)
        {
            noahStateMachineManager.SwitchState(noahStateMachineManager.getJumpState);
        }
        if (PlayerInputManager.getCurrent.getIsCrouched)
        {
            noahStateMachineManager.SwitchState(noahStateMachineManager.getCrouchState);
        }
    }
}
