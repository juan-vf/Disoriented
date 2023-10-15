using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class CrouchState : NoahBaseState
{
    
    public override void EnterState(NoahStateMachineManager noahStateMachineManager)
    {
        // noahStateMachineManager.GetNoahAnimatorController.StartCrouch(true);
        noahStateMachineManager.GetNoahController.SetCrouchedCollider();
    }

    public override void ExitState(NoahStateMachineManager noahStateMachineManager)
    {
    }

    public override void OnTriggerEnter(Collider other)
    {
    }

    public override void UpdateState(NoahStateMachineManager noahStateMachineManager)
    {
        if(PlayerInputManager.getCurrent.getIsJumping){
            noahStateMachineManager.SwitchState(noahStateMachineManager.getJumpState);
        }
        if(!PlayerInputManager.getCurrent.getIsCrouched){
            noahStateMachineManager.SwitchState(noahStateMachineManager.getNoahDefaultState);
        }
    }
}
