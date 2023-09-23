using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PetBaseState
{
    public abstract void EnterState(PetStateMachineManager stateMachine);

    public abstract void ExitState(PetStateMachineManager stateMachine);

    public abstract void OnTriggerEnter(Collider other);

    public abstract void UpdateState(PetStateMachineManager stateMachine);
}
