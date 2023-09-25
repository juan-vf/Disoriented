using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class NoahController : MonoBehaviour
{
    private static NoahController _current;
    private Rigidbody _rb;
    private MovementComponent _movementComponent;
    private Vector3 _movement;
    private ClimbComponent _climbComponent;
    private Vector2 _climbMovement;
    private bool _isFinishClimbing = false;
    private NoahStateMachineManager _noahStateMachineManager;
    [Header("Collect")]
    [SerializeField] private LayerMask _collectibleLayer;
    private bool _raycastForCollect;
    [SerializeField]private bool _hide;
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
    void Update()
    {
        Debug.DrawRay(_rb.transform.position + Vector3.up * .1f, _rb.transform.forward, Color.red);

        _isFinishClimbing = _climbComponent.getFinishClimbing;
        //ANALIZAR CUANDO ESTE SALTANDO
        if (_noahStateMachineManager.getCurrentState == _noahStateMachineManager.getNoahClimbState)
        {
            _climbMovement = new Vector2(PlayerInputManager.getCurrent.getMove.x, PlayerInputManager.getCurrent.getMove.y).normalized;
            _climbComponent.Climb(_climbMovement);
        }
        else
        {
            _movement = new Vector3(PlayerInputManager.getCurrent.getMove.x, 0f, PlayerInputManager.getCurrent.getMove.y);
            _movementComponent.Move(_movement);
        }
        //ADEMAS LANZA EL RAYO PARA SABER SI PEGO
        // if (PlayerInputManager.getCurrent.getIsPickedUp)
        // {
        //     if (Collect())
        //     {
        //         PetEventsManager.GetCurrent.GrabPet();
        //     }
        // }

    }
    void HiddenUpdates(bool value){
        _hide = value;
    }
    // private void OnCollisionEnter(Collision other) {
    //     if(other.gameObject.CompareTag("Tree")){
    //         _climbComponent.getFinishClimbing = true;
    //     }
    // }
    // private void OnCollisionExit(Collision other) {
    //     if(other.gameObject.CompareTag("Tree")){
    //         _climbComponent.getFinishClimbing = false;
    //     }
    // }
    /*
    bool Collect()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up, transform.forward, out hit, 5f, _collectibleLayer))
        {
        Debug.Log("LANZA RAYO Y PEGA");
            Debug.DrawRay(transform.position + Vector3.up, transform.forward * 5f, Color.red, 20f);
            return true;
        }
        return false;
    }
    */
    public bool GetIsFinishClimbing { get { return _isFinishClimbing; } }
    public bool GetHide{get {return _hide;}}

}
