
using UnityEngine;

public class CarriageBrokenState : CarriageBaseState
{
    public GameObject CarriageOpen;
    public override void EnterState(CarriageStateManager carriage)
    {
        Debug.Log("Estoy roto");
        // TODO:  carriage broken
        // TODO: animate carriage broken then change the scene.
        carriage.GetComponent<MeshFilter>().mesh = carriage.GetOpenCarriage;
        carriage.GetComponent<MeshFilter>().transform.localRotation = Quaternion.Euler(-90, 0, 0);


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
