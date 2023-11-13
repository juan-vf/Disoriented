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
    private NoahStateMachineManager _noahStateMachineManager;
    private NoahAnimatorController _noahAnimatorController;
    private Vector3 _movement;
    private ClimbComponent _climbComponent;
    private Vector2 _climbMovement;
    private CollectComponent _collectComponent;
    private Vector2 _climbFloats;
    private bool _isFinishClimbing = false;
    [SerializeField] private LayerMask _climbMask;
    [SerializeField] private NoahAudios _noahAudio;
    [Header("Collect")]
    [SerializeField] private LayerMask _collectibleLayer;
    private bool _raycastForCollect;
    [SerializeField] private bool _hide;
    [Header("Colliders")]
    [SerializeField] private CapsuleCollider _crouchedCollider;
    [SerializeField] private CapsuleCollider _standingCollider;
    [SerializeField] private CapsuleCollider _jumpCollider;
    [Header("BackPack")]
    [SerializeField] private Transform _backPackOrigin;
    [Header("Events")]
    [SerializeField] private EventWithVariables _audioCaller;
    private BackpackControllerTest _backpackControllerTest;
    private bool _onGround;
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log(_audioCaller == null);
        _current = this;
        _rb = GetComponent<Rigidbody>();
        _noahStateMachineManager = GetComponent<NoahStateMachineManager>();
        _noahAnimatorController = GetComponent<NoahAnimatorController>();
        _collectComponent = GetComponent<CollectComponent>();

        _backpackControllerTest = _backPackOrigin.GetComponent<BackpackControllerTest>();

        //COMPONENTES
        _movementComponent = new MovementComponent(_rb);
        _climbComponent = new ClimbComponent(_rb, _rb.position, _climbMask);
        // _collectComponent = new CollectComponent(_rb);
        EnviorementEventsController.GetCurrent.onHiddenPlayer += HiddenUpdates;
        PetEventsManager.GetCurrent.onSendPetData += AddPet;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        _noahAnimatorController.SetVelocity(PlayerInputManager.getCurrent.GetVelocity);
        //VARIOS IF() SE PODRIAN EVITAR SI EL PLAYERINPUTMANAGER CONTROLA LA ANIMACION O LA ORDEN EN SI
        if (PlayerInputManager.getCurrent.getIsPickedUp && _collectComponent.PetToCollect(_rb))
        {
            _noahAnimatorController.IsCollecting();
            _noahAnimatorController.EndCollecting(false);
            // _audioCaller.OnEventAudioClip(_noahAudio.GetSaveInBackPack);
            /*
                LANZAR EVENTO PARA QUE RECOJA LA PELOTA Y SE GUARDE EN LA MOCHILA
                QUE NO SE EJECUTE SI JUSTO SE DA VUELTA, APRETA LA TECLA Y SE DA VUELTA, SINO LA ANIMACION SE EJECUTA DE ESPALDAS A LA MASCOTA
            */
        }
        else { _noahAnimatorController.EndCollecting(true); }


        _isFinishClimbing = _climbComponent.getFinishClimbing;
        //LOGICA DE SALTO, DIFERENTES INPUTS(VECTOR3 O 2), Y SI DEBE MOVERSE EN PROFUNDIDAD(Z) O DE LADO(X)
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
        else if (_onGround != false)
        {
            _movement = new Vector3(PlayerInputManager.getCurrent.getMove.x, 0f, PlayerInputManager.getCurrent.getMove.y);
            _movementComponent.Move(_movement);
            if (PlayerInputManager.getCurrent.getMove != Vector2.zero && _onGround == true)
            {
                if (_audioCaller != null)
                {
                    _audioCaller.OnEventAudioClip(_noahAudio.GetRun);
                }
            }
            else
            {
                if (_audioCaller != null)
                {
                    _audioCaller.OnEventInt(1);
                }
            }
        }


        RaycastHit hit;
        _onGround = Physics.Raycast(_rb.transform.position, Vector3.down, out hit, .3f);

        // if(_noahStateMachineManager.getCurrentState != _noahStateMachineManager.getJumpState && _onGround){SetStandingCollider();}

        _noahStateMachineManager.GetNoahAnimatorController.OnGround(_onGround);

        _noahStateMachineManager.GetNoahAnimatorController.Crouch(PlayerInputManager.getCurrent.getIsCrouched);
        // if(_rb.velocity != Vector3.zero){
        //     // _audioCaller.OnEventAudioClip(_noahAudio.GetRun);
        // }
    }
    void HiddenUpdates(bool value)
    {
        _hide = value;
    }
    void AddPet(int id, int serialId)
    {
        _backpackControllerTest.AddPet(id, serialId);
    }
    public bool GetIsFinishClimbing { get { return _isFinishClimbing; } }
    public bool GetHide { get { return _hide; } }
    public bool GetOnGround { get { return _onGround; } }

    public void SetCrouchedCollider()
    {
        _crouchedCollider.enabled = true;
        _standingCollider.enabled = false;
        _jumpCollider.enabled = false;
    }
    public void SetStandingCollider()
    {
        _standingCollider.enabled = true;
        _crouchedCollider.enabled = false;
        _jumpCollider.enabled = false;
    }
    public void SetJumpCollider()
    {
        _jumpCollider.enabled = true;
        _crouchedCollider.enabled = false;
        _standingCollider.enabled = false;
    }
    public void EnaDisaColliders(string name, bool value)
    {
        if (name == "jump") { _jumpCollider.enabled = value; }
        if (name == "crouch") { _crouchedCollider.enabled = value; }
        if (name == "standing") { _standingCollider.enabled = value; }
    }
    public Vector2 GetClimbMovement { get { return _climbFloats; } }
    public LayerMask GetClimbLayer { get => _climbMask; }
    public MovementComponent GetMovementComponent { get { return _movementComponent; } }

}
