using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class BaseState
{
    public abstract void EnterState(EnemieStateMachineManager enemieStateMachineManager);
    public abstract void UpdateState(EnemieStateMachineManager enemieStateMachineManager);
    public abstract void ExitState(EnemieStateMachineManager enemieStateMachineManager);
    public abstract void OnTriggerEnter(Collider other);

}
