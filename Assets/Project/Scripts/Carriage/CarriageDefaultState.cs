
using UnityEngine;

public class CarriageDefaultState : CarriageBaseState
{
    public int petCount;
    private int _maxPetCount;
    public override void EnterState(CarriageStateManager carriage)
    {
        CarriageEventController.GetCurrent.onChangeFullState += addPet;
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

    void addPet()
    {
        petCount++;
    }
}
