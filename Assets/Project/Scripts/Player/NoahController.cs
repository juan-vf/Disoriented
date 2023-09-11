using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class NoahController : MonoBehaviour
{
    private Rigidbody _rb;
    private MovementComponent _movementComponent;
    private Vector3 _movement;
    private ClimbComponent _climbComponent;
    private Vector2 _climbMovement;
    private NoahStateMachineManager _noahStateMachineManager;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _noahStateMachineManager = GetComponent<NoahStateMachineManager>();
        //COMPONENTES
        _movementComponent = new MovementComponent(_rb);
        _climbComponent = new ClimbComponent(_rb);
    }

    // Update is called once per frame
    void Update()
    {
        //ANALIZAR CUANDO ESTE SALTANDO
        if(_noahStateMachineManager.getCurrentState == _noahStateMachineManager.getNoahClimbState){
            _climbMovement = new Vector2(PlayerInputManager.getCurrent.getMove.x, PlayerInputManager.getCurrent.getMove.y).normalized;
            _climbComponent.Climb(_climbMovement);
        }else{
            _movement = new Vector3(PlayerInputManager.getCurrent.getMove.x, 0f, PlayerInputManager.getCurrent.getMove.y);
            _movementComponent.Move(_movement);
        }
    }
}
