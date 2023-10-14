using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class CrouchState : NoahBaseState
{
    private CapsuleCollider _capsuleCollider;
    private Vector3 _center = new Vector3(.0f, .43f, .0f);
    private float _height = .8f;
    //NORMAL VALUES
    private Vector3 _oldCenter = new Vector3(.0f, .43f, .0f);
    private float _oldHeight = .9f;
    public override void EnterState(NoahStateMachineManager noahStateMachineManager)
    {
        noahStateMachineManager.GetNoahAnimatorController.StartCrouch(true);
        _capsuleCollider = noahStateMachineManager.GetComponent<CapsuleCollider>();
        _oldCenter = _capsuleCollider.center;
        _oldHeight = _capsuleCollider.height;
        // noahStateMachineManager.transform.localScale = new Vector3(1f, .5f, 1f);
        _capsuleCollider.height = _height;
        // _capsuleCollider.center = _center;
    }

    public override void ExitState(NoahStateMachineManager noahStateMachineManager)
    {
        Debug.Log("NO ESTA AGACHHADO");
        noahStateMachineManager.GetNoahAnimatorController.StartCrouch(false);
        _capsuleCollider.center = _oldCenter;
        _capsuleCollider.height = _oldHeight;
        noahStateMachineManager.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public override void OnTriggerEnter(Collider other)
    {
        throw new System.NotImplementedException();
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
