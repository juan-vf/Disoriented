using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStateMachine : MonoBehaviour
{
    public abstract void Start();
    public abstract void Update();
    public abstract void OnTriggerEnter(Collider other);
    public abstract void SwitchState(BaseState nextState);
}
