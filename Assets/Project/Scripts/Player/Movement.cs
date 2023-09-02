using System.Collections;
using System.Collections.Generic;

// using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Rigidbody _rb;
    private PlayerInput _playerInput;
    [SerializeField] private Transform _position;
    [SerializeField] private Transform _positionBack;

    private Vector2 _input;
    private Vector3 _movement;
    [SerializeField] private float moveSpeed = 3f;

    [SerializeField] private float _upForce = 250f;
    
    [SerializeField] private float _force = 3f;
    [SerializeField] private float _climbForce = 0f;
    private bool _isGrounded = true;

    [Header("Climbing")]
    private bool _isClimbing = false;
    private bool _isNearTree = false;
    private bool _isClimbingAlready = false;

    [Header("Crouching")]
    private bool _isCrouching = false;
    private float _crouchSpeed;
    private float _crouchYScale = 0.5f;
    private float startYScale = 1f;

    public LayerMask petLayer;
    public float rangeRaycast = 2f;
    public GameObject pet;


    private GameObject _nearTree;


    //ReformatCode
    private PlayerInputManager _playerInputManager;

    [SerializeField]
    private float _timeStop;
    private bool _isMoving = false;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _playerInputManager = GetComponent<PlayerInputManager>();
        // _playerInput = GetComponent<PlayerInput>();
        // startYScale = transform.localScale.y;
    }

    
    void Update()
    {
        // _input = _playerInput.actions["Move"].ReadValue<Vector2>();
        // SpeedControl();

    }
    public void FixedUpdate()
    {
        Move();

    }

    public void SpeedControl()
    {
        Vector3 flatVel = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            _rb.velocity = new Vector3(limitedVel.x, _rb.velocity.y, limitedVel.z);
        }
    }
    //TODO: Corregir frenada cuando el personaje termina el salto.
    // public void Jump(InputAction.CallbackContext callbackContext)
    // {
    //     if (callbackContext.performed && _isGrounded)
    //     {
    //         _rb.velocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);
    //         _rb.AddForce(Vector3.up * _upForce, ForceMode.Force);
    //         _isGrounded = false;            
    //     }
    // }

    public void Move()
    {
        Vector3 _movement = new Vector3(_playerInputManager.getMove.x, 0f, _playerInputManager.getMove.y);

        if (_movement != Vector3.zero)
        {
            _isMoving = true;
            
        }else if(_isMoving)
        {
            StartCoroutine(Lerp(_timeStop, _rb.velocity, Vector3.zero));
            _isMoving = false;
        }
        Quaternion targetRotation = Quaternion.LookRotation(_movement);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * 10f);
        _rb.AddForce(_movement * _force);
    }

    IEnumerator Lerp(float endTime, Vector3 A, Vector3 B){
        float timeElapsed = 0f;

        while(timeElapsed < endTime){
            _rb.velocity = Vector3.Lerp(A, B, timeElapsed / endTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        _rb.velocity = B;
    }


    //TODO: Hacer que tome el climb otra vez antes de tocar el suelo.
    // public void Climb(InputAction.CallbackContext callbackContext)
    // {
    //     if (callbackContext.performed && _isNearTree && !_isClimbing && !_isClimbingAlready)
    //     {
    //         Debug.Log("Comenzaste a escalar el arbol");
    //         _isClimbingAlready = true; 
    //         _rb.useGravity = false;
    //         // Mover el personaje hacia arriba mientras trepa
    //         _climbForce = 120f; // Fuerza de climb
    //         Vector3 climbMovement = Vector3.up * _climbForce;
    //         _rb.AddForce(climbMovement, ForceMode.Force);
    //     } else if (callbackContext.canceled && _isClimbingAlready)
    //     {
    //         _isClimbing = false;
    //         _rb.useGravity = true;            
    //     }

    // }
    // public void Crouch(InputAction.CallbackContext callbackContext)
    // {
    //     if (callbackContext.performed)
    //     {
    //         transform.localScale = new Vector3(transform.localScale.x, _crouchYScale, transform.localScale.z);
    //         _rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
    //         _isCrouching = true;
    //     }
    //     else if (callbackContext.canceled)
    //     {
    //         transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
    //         _isCrouching = false;            
    //     }
    // }

    // public void Collect(InputAction.CallbackContext callbackContext)
    // {
    //     if (callbackContext.performed)
    //     {
    //         Debug.Log("Item Collected");
    //         Vector3 rayOrigin = transform.position;
    //         Vector3 rayDirection = transform.forward;

    //         RaycastHit hit;
    //         if (Physics.Raycast(rayOrigin, rayDirection, out hit, rangeRaycast, petLayer))
    //         {
    //             Debug.Log("Pego el rayo");
    //             GameObject hitObject = hit.collider.gameObject;
    //             if (hitObject.CompareTag("Pet"))
    //             {
    //                 Instantiate(pet, _positionBack.position, Quaternion.identity, _position);
    //             }
    //         }
    //         Debug.DrawRay(rayOrigin, rayDirection * rangeRaycast, Color.red, 20f);
    //     }
    // }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Ground")) 
    //     {
    //         _isGrounded = true;
    //         _rb.useGravity = true;
    //         _isClimbingAlready = false;
    //     }
    //     if (collision.gameObject.CompareTag("Tree"))
    //     {
    //         Debug.Log("Estas cerca del arbol");
    //         _isNearTree = true;
    //         _nearTree = collision.gameObject;
    //     }

    // }

    // private void OnCollisionExit(Collision collision) 
    // {
    //     if (collision.gameObject == _nearTree)
    //     {
    //         Debug.Log("Te alejaste del arbol");
    //         _isNearTree = false;
    //         _nearTree = null;
    //         _rb.useGravity = true;

    //     }

    // }
 
}
