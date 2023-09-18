using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;
public class PetStateMachineManager : MonoBehaviour
{
    /*
    public PetBaseState _currentState;
    public UnCollectedState _unCollectedState = new UnCollectedState();
    public PetBaseState _collectedState = new CollectedState();
    private PetController _petController;
    private bool _collected = false;

    public PetBaseState GetCurrentState
    {
        get { return _currentState; }
        // set { _currentState = _currentState;}
    }

    public void Start()
    {
        _petController = GetComponent<PetController>();
        _currentState = _unCollectedState;
        _currentState.EnterState(this);
    }
    public void Update()
    {
        _currentState.UpdateState(this);

        if (_unCollectedState.GetIsPickedUp)
        {
            Destroy(gameObject);
        }
    }
    public void Exit()
    {
        _currentState.ExitState(this);
    }

    public void OnTriggerEnter(Collider other)
    {
    }

    public void SwitchState(PetBaseState nextState)
    {
        if (nextState != null)
        {
            _currentState.ExitState(this);
            _currentState = nextState;
            _currentState.EnterState(this);
        }
    }
    public PetController GetPetController { get { return _petController; } }
    public bool GetCollected { get { return _collected; } set { _collected = value; } }
    */

}
