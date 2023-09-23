using System.Collections;
using System.Collections.Generic;
using Disoriented.Assets.Project.Scripts.Enemies;
using UnityEngine;
using UnityEngine.AI;

public class EnemieStateMachineManager : MonoBehaviour
{
    [SerializeField] private string _currentStateString;
    private BaseState _currentState;
    private EnemieManager _enemieManager;
    
    private BaseState _defaultState = new TransportState();
    private BaseState _persuitState = new PersuitState();
    private BaseState _searchState = new SearchState();
    private BaseState _transportState = new TransportState();
    public void Start()
    {
        //EVENTOS
        PetEventsManager.GetCurrent.onCallEnemieToTransport += InitTransport;
        //
        _enemieManager = GetComponent<EnemieManager>();
        

        _currentState = _defaultState;
        _currentState.EnterState(this);
    }

    public void Update()
    {
        _currentStateString = _currentState.ToString();
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
    private void OnCollisionEnter(Collision other) {
        _currentState.OnCollisionEnter(other);
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }
    void InitTransport(){
        SwitchState(_transportState);
    }

    //GetAndSet
    public BaseState getCurrentState{get{return _currentState;}}
    public BaseState getPersuitState{get{return _persuitState;}}
    public BaseState GetSearchState{get{return _searchState;}}
    public BaseState getTransportState{get{return _transportState;}}
    public EnemieManager GetEnemieManager{get{return _enemieManager;}}

}
