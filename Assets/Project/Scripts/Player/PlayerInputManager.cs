using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    private static PlayerInputManager _current;
    private PlayerInput _playerInput;
    private Vector2 _move;
    // private InputAction _IsClimbing;
    private bool _IsClimbing;
    private bool _IsJumping;
    private bool _IsCrouched = false;
    private bool _IsPickedUp;
    private float _velocity = 0.0f;
    private float _acceleration = 2f;
    private float _deceleration = 15f;
    private float _maxVelocity = 1f;
    private float _minVelocity = 0f;
    //VARIABLES PARA CONSULTAS
    private bool _isMovingCrouching = false;
    void Awake()
    {
        _current = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {

        _move = _playerInput.actions["Move"].ReadValue<Vector2>();

        if (_current.getMove != Vector2.zero && _velocity < _maxVelocity)
        {
            _velocity += Time.deltaTime * _acceleration;
        }
        if (_current.getMove == Vector2.zero && _velocity > _minVelocity)
        {
            _velocity -= Time.deltaTime * _deceleration;
        }
        if (_current.getMove == Vector2.zero && _velocity < 0.0f)
        {
            _velocity = 0.0f;
        }

        _isMovingCrouching = (_move.magnitude > Vector2.zero.magnitude && _IsCrouched == true) ? true : false;
    }
    public void Climb(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            _IsClimbing = true;
        }
        else if (callbackContext.canceled)
        {
            _IsClimbing = false;
        }
    }
    public void Jump(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started || callbackContext.performed)
        {
            _IsJumping = true;
        }
        else if (callbackContext.canceled)
        {
            _IsJumping = false;
        }
    }
    public void Crouch(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            _IsCrouched = true;
        }
        if (callbackContext.canceled)
        {
            _IsCrouched = false;
        }
        if (callbackContext.performed)
        {
            _IsCrouched = true;
        }
    }
    public void Collect(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            _IsPickedUp = true;
        }
        if(callbackContext.canceled){
            _IsPickedUp = false;
        }
        if (callbackContext.performed)
        {
            _IsPickedUp = false;
        }
    }
    public static PlayerInputManager getCurrent { get { return _current; } }
    public Vector2 getMove { get { return _move; } }
    public bool getIsClimbing { get { return _IsClimbing; } }
    public bool getIsJumping { get { return _IsJumping; } }
    public bool getIsCrouched { get { return _IsCrouched; } }
    public bool getIsPickedUp { get { return _IsPickedUp; } }
    public float GetVelocity { get { return _velocity; } }
    public bool GetIsMovingCrouching { get { return _isMovingCrouching; } }
}
