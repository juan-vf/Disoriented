using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarriageStateManager : MonoBehaviour
{
    CarriageBaseState _currentState;
    public CarriageFullState CarriageFullState = new CarriageFullState();
    public CarriageBrokenState CarriageBrokenState = new CarriageBrokenState();
    public CarriageDefaultState CarriageDefaultState = new CarriageDefaultState();

    void Start()
    {
        _currentState = CarriageDefaultState;

    }

    // Update is called once per frame
    void Update()
    {
        _currentState.UpdateState(this);
    }

    public void SwitchState(CarriageBaseState state)
    {
        _currentState = state;
        state.EnterState(this);
    }
}
