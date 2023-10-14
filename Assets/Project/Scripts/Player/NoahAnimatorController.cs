using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoahAnimatorController : MonoBehaviour
{
    private Animator _animator;
    private float _velocity = 0.0f;
    private float _acceleration = 0.1f;
    private float _deceleration = 0.5f;
    private int _velocityHash;
    private int _triggerJump;
    private int _onGround;
    private int _verticalVelocity;
    private int _endJumping;
    private int _isCrouch;
    
    // Start is called before the first frame update
    void Start()
    {
        //Get Hash variables
        _animator = GetComponent<Animator>();
        _velocityHash = Animator.StringToHash("Velocity");
        _triggerJump = Animator.StringToHash("Jump");
        _onGround = Animator.StringToHash("OnGround");
        _verticalVelocity = Animator.StringToHash("VerticalVelocity");

        //Set Hash variables
        _animator.SetBool(_onGround, true);

        _endJumping = Animator.StringToHash("EndJumping");
        _isCrouch = Animator.StringToHash("IsCrouch");
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerInputManager.getCurrent.getMove != Vector2.zero && _velocity < 1.0f){
            _velocity += Time.deltaTime * _acceleration;
        }
        if(PlayerInputManager.getCurrent.getMove == Vector2.zero && _velocity > 0.0f){
            _velocity -=Time.deltaTime * _deceleration;
        }
        if(PlayerInputManager.getCurrent.getMove == Vector2.zero && _velocity < 0.0f){
            _velocity = 0.0f;
        }

        _animator.SetFloat(_velocityHash, _velocity);
    }
    public void Jump(){
        _animator.SetTrigger(_triggerJump);
    }
    public void OnGround(bool value){
        _animator.SetBool(_onGround, value);
    }
    public void JumpVelocity(float velocity){
        _animator.SetFloat(_verticalVelocity, velocity);
    }

    public void EndJump(bool value){
        _animator.SetBool(_endJumping, value);
    }
    public void StartCrouch(bool value){
        _animator.SetBool(_isCrouch, value);
    }
}
