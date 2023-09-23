using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NoahBaseState
{
    public abstract void EnterState(NoahStateMachineManager noahStateMachineManager);
    public abstract void UpdateState(NoahStateMachineManager noahStateMachineManager);
    public abstract void ExitState(NoahStateMachineManager noahStateMachineManager);
    public abstract void OnTriggerEnter(Collider other);
}
