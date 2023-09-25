using UnityEngine;

public class CarriageDefaultState : CarriageBaseState
{
    public int petCount = 0;
    private int _maxPetCountSpawned = 0;
    private int _petActualCount = -10;
    
    
    // primero == cantidad de valores en la lista
    // cuando la lista tenga 0 valores lanzar el evento
    public override void EnterState(CarriageStateManager carriage)
    {
        Debug.Log("Estoy en default state");
        CarriageEventController.GetCurrent.onAddPet += addPet;
        CarriageEventController.GetCurrent.onUpdateMaxCountCarriage += MaxCountPet;
        Debug.Log("Pet actual count: " + _petActualCount);



    }
    public override void ExitState(CarriageStateManager carriage)
    {

    }
    public override void UpdateState(CarriageStateManager carriage)
    {
        Debug.Log(_maxPetCountSpawned);
        if (petCount >= 0.70 * _maxPetCountSpawned)
        {
            
            carriage.SwitchState(carriage.CarriageFullState);

        }
        if (petCount <= 0.70 * _maxPetCountSpawned && _petActualCount == 0)
        {
            carriage.SwitchState(carriage.CarriageBrokenState);

        }
    }
    public override void OnTriggerEnter(Collider other)
    {

    }

    public override void OnCollisionEnter(Collision other)
    {

    }

    void addPet(int id)
    {
        petCount++;
    }
    void MaxCountPet(int count)
    {

        if (count > _maxPetCountSpawned) 
        {
            _maxPetCountSpawned = count;
        }
        else
        {
         
            _petActualCount = count;
        }
    }
}
