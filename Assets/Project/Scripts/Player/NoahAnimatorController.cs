using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoahAnimatorController : MonoBehaviour
{
    private Animator _animator;
    private Movement _movement;
    private float _velocity = 0.0f;
    private float _acceleration = 0.1f;
    private float _deceleration = 0.5f;
    private int _velocityHash;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _velocityHash = Animator.StringToHash("Velocity");
        // _movement = GetComponent<Movement>();
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
}
