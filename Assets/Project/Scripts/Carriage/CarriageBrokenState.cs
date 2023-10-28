
using UnityEngine;

public class CarriageBrokenState : CarriageBaseState
{
    public GameObject CarriageOpen;
    public override void EnterState(CarriageStateManager carriage)
    {
        Debug.Log("Estoy roto");
        // TODO:  carriage broken
        // TODO: animate carriage broken then change the scene.
        GameObject a = MonoBehaviour.Instantiate(carriage.GetCloseCarriage, carriage.transform.position, Quaternion.identity, carriage.transform);
        //LANZO ENVENTO PARA QUE EL ENEMIGO SE VAYA
        CarriageEventController.GetCurrent.EnemyLeaves();

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
