using System.Collections;
using System.Collections.Generic;
using System.Timers;
using Unity.VisualScripting;
using UnityEngine;

public class NoahController : MonoBehaviour
{
    private static NoahController _current;
    private Rigidbody _rb;
    private MovementComponent _movementComponent;
    private Vector3 _movement;
    private ClimbComponent _climbComponent;
    private Vector2 _climbMovement;
    private Vector2 _climbFloats;
    private bool _isFinishClimbing = false;
    private NoahStateMachineManager _noahStateMachineManager;
    [Header("Collect")]
    [SerializeField] private LayerMask _collectibleLayer;
    private bool _raycastForCollect;
    [SerializeField] private bool _hide;
    [Header("Colliders")]
    [SerializeField] private CapsuleCollider _crouchedCollider;
    [SerializeField] private CapsuleCollider _standingCollider;

    private bool _onGround;
    // Start is called before the first frame update
    void Start()
    {
        _current = this;
        _rb = GetComponent<Rigidbody>();
        _noahStateMachineManager = GetComponent<NoahStateMachineManager>();
        //COMPONENTES
        _movementComponent = new MovementComponent(_rb);
        _climbComponent = new ClimbComponent(_rb);
        EnviorementEventsController.GetCurrent.onHiddenPlayer += HiddenUpdates;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _isFinishClimbing = _climbComponent.getFinishClimbing;
        //ANALIZAR CUANDO ESTE SALTANDO
        if (_noahStateMachineManager.getCurrentState == _noahStateMachineManager.getNoahClimbState)
        {
            _climbMovement = new Vector2(PlayerInputManager.getCurrent.getMove.x, PlayerInputManager.getCurrent.getMove.y).normalized;
            _climbComponent.Climb(_climbMovement);
            if (_rb.velocity.x <= 2.384186E-07f)
            {
                if (_rb.velocity.x == -1.5f)
                {
                    _climbFloats = new Vector2(_rb.velocity.x * .1f, _rb.velocity.y * .1f);
                }
                else
                {
                    _climbFloats = new Vector2(_rb.velocity.z * .1f, _rb.velocity.y * .1f);
                }

                Debug.Log(_rb.velocity.x);
            }
            else
            {
                _climbFloats = new Vector2(_rb.velocity.x * .1f, _rb.velocity.y * .1f);
            }
        }
        else
        {
            _movement = new Vector3(PlayerInputManager.getCurrent.getMove.x, 0f, PlayerInputManager.getCurrent.getMove.y);
            _movementComponent.Move(_movement);
        }

        RaycastHit hit;
        _onGround = Physics.Raycast(_rb.transform.position, Vector3.down, out hit, .05f);

        _noahStateMachineManager.GetNoahAnimatorController.OnGround(_onGround);

        _noahStateMachineManager.GetNoahAnimatorController.Crouch(PlayerInputManager.getCurrent.getIsCrouched);

    }
    void HiddenUpdates(bool value)
    {
        _hide = value;
    }
    public bool GetIsFinishClimbing { get { return _isFinishClimbing; } }
    public bool GetHide { get { return _hide; } }
    public bool GetOnGround { get { return _onGround; } }

    public void SetCrouchedCollider()
    {
        _crouchedCollider.enabled = true;
        _standingCollider.enabled = false;
    }
    public void SetStandingCollider()
    {
        _crouchedCollider.enabled = false;
        _standingCollider.enabled = true;
    }
    public Vector2 GetClimbMovement { get { return _climbFloats; } }

}
