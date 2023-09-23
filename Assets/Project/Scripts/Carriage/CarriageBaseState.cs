using UnityEngine;

public abstract class CarriageBaseState
{
    public abstract void EnterState(CarriageStateManager carriage);
    public abstract void UpdateState(CarriageStateManager carriage);
    public abstract void ExitState(CarriageStateManager carriage);
    public abstract void OnTriggerEnter(Collider other);

}
