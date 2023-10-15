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
    private int _isJumping;
    private int _onGround;
    private int _verticalVelocity;
    private int _isCrouched;
    private int _verticalClimb;
    private int _horizontalClimb;
    private int _isClimbing;
    private int _endJumping;
    
    // Start is called before the first frame update
    void Start()
    {
        //Get Hash variables
        _animator = GetComponent<Animator>();
        _velocityHash = Animator.StringToHash("Velocity");
        _triggerJump = Animator.StringToHash("Jump");
        _onGround = Animator.StringToHash("OnGround");
        _verticalVelocity = Animator.StringToHash("VerticalVelocity");
        _isCrouched = Animator.StringToHash("IsCrouched");
        _isJumping = Animator.StringToHash("IsJumping");
        _verticalClimb = Animator.StringToHash("VerticalClimb");
        _horizontalClimb = Animator.StringToHash("HorizontalClimb");
        _isClimbing = Animator.StringToHash("IsClimbing");

        //Set Hash variables
        _animator.SetBool(_onGround, true);

        _endJumping = Animator.StringToHash("EndJumping");
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
    public void Jump(bool value){
        // _animator.SetBool(_isJumping, value);
        _animator.SetTrigger(_triggerJump);
    }
    public void OnGround(bool value){
        _animator.SetBool(_onGround, value);
    }
    public void JumpVelocity(float velocity){
        _animator.SetFloat(_verticalVelocity, velocity);
    }
    public void Crouch(bool value){
        _animator.SetBool(_isCrouched, value);
    }
    public void ClimbFloats(float vertical, float horizontal){
        _animator.SetFloat(_verticalClimb, vertical);
        _animator.SetFloat(_horizontalClimb, horizontal);
    }
    public void IsClimbing(bool value){
        _animator.SetBool(_isClimbing, value);
    }

    public void EndJump(bool value){
        _animator.SetBool(_endJumping, value);
    }

}
