using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStateMachine : MonoBehaviour
{
    public PetBaseState _currentState;
    public abstract void Start();
    public abstract void Update();
    public abstract void Exit();
    public abstract void OnTriggerEnter(Collider other);
    public abstract void SwitchState(PetBaseState nextState);
    public abstract PetBaseState GetCurrentState{get;}
}
