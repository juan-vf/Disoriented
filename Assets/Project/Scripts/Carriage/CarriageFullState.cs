using UnityEngine;

public class CarriageFullState : CarriageBaseState
{
    public override void EnterState(CarriageStateManager carriage)
    {
        SceneEventController.GetCurrent.LoadLooseScene();
        Debug.Log("JAJAJ");
    }
    public override void ExitState(CarriageStateManager carriage)
    {

    }
    public override void UpdateState(CarriageStateManager carriage)
    {

    }
    public override void OnTriggerEnter(Collider other)
    {

    }
    public override void OnCollisionEnter(Collision other)
    {
        throw new System.NotImplementedException();
    }
}
