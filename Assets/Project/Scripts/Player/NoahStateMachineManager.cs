using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoahStateMachineManager : MonoBehaviour
{
    private NoahBaseState _currentState;
    private NoahBaseState _defaultState = new NoahDefaultState();
    private NoahBaseState _ClimbState = new NoahClimbState();
    private NoahBaseState _JumpState = new NoahJumpState();

    private PlayerInputManager _playerInputManager;
    private Rigidbody _rb;
    void Start()
    {
        _playerInputManager = PlayerInputManager.getCurrent;
        _rb = GetComponent<Rigidbody>();
        _currentState = _defaultState;
        _currentState.EnterState(this);
    }
    // Update is called once per frame
    void Update()
    {
        _currentState.UpdateState(this);
    }
    private void FixedUpdate() {
        _rb.useGravity = _currentState != _ClimbState;
    }
        public void SwitchState(NoahBaseState nextState)
    {
        if(nextState != null){
            _currentState.ExitState(this);
            _currentState = nextState;
            _currentState.EnterState(this);
        }
    }
    public PlayerInputManager GetPlayerInputManager{get{return _playerInputManager;}}
    public NoahBaseState getNoahDefaultState{get{return _defaultState;}}
    public NoahBaseState getNoahClimbState{get{return _ClimbState;}}
    public NoahBaseState getJumpState{get{return _JumpState;}}
    public Rigidbody GetRigidbody{get{return _rb;}}
}
