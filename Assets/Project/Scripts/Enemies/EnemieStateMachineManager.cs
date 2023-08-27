using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemieStateMachineManager : MonoBehaviour
{
    private BaseState _currentState;
    private EnemieManager _enemieManager;
    
    private BaseState _defaultState = new SearchState();
    public void Start()
    {
        _enemieManager = GetComponent<EnemieManager>();
        

        _currentState = _defaultState;
        _currentState.EnterState(this);
    }

    public void Update()
    {
        _currentState.UpdateState(this);
    }
    public void SwitchState(BaseState nextState)
    {
        if(nextState != null){
            _currentState.ExitState(this);
            _currentState = nextState;
            _currentState.EnterState(this);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        _currentState.OnTriggerEnter(other);
    }
    //GetAndSet
    public BaseState getCurrentState{get{return _currentState;}}
    public EnemieManager GetEnemieManager{get{return _enemieManager;}}
}
