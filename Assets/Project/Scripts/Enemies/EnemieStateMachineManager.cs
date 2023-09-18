using System.Collections;
using System.Collections.Generic;
using Disoriented.Assets.Project.Scripts.Enemies;
using UnityEngine;
using UnityEngine.AI;

public class EnemieStateMachineManager : MonoBehaviour
{
    private BaseState _currentState;
    private EnemieManager _enemieManager;
    
    private BaseState _defaultState = new TransportState();
    private BaseState _persuitState = new PersuitState();
    private BaseState _searchState = new SearchState();
    private BaseState _transportState = new TransportState();
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

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

    //GetAndSet
    public BaseState getCurrentState{get{return _currentState;}}
    public BaseState getPersuitState{get{return _persuitState;}}
    public BaseState GetSearchState{get{return _searchState;}}
    public BaseState getTransportState{get{return _transportState;}}
    public EnemieManager GetEnemieManager{get{return _enemieManager;}}

}
