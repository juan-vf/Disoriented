using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoahAnimatorController : MonoBehaviour
{
    private Animator _animator;
    private Movement _movement;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        // _movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        // Walk();
        // Jump();
        // Idle();
    }
    private void Idle()
    {
        if (!_movement.getIsMoving)
        {
            _animator.SetBool("IsWalking", false);
            // _animator.SetBool("IsJumping", false);
            _animator.SetBool("IsIdle", true);
        }
    }
    private void Jump() { 
        if(_movement.getIsJumping){
            _animator.SetBool("IsJumping", true);
            // _animator.SetBool("IsIdle", false);
            Debug.Log(_movement.getIsJumping);
            // _animator.SetBool("IsWalking", false);
            _animator.SetBool("IsJumping", false);
        }
    }
    private void Walk()
    {
        if (_movement.getIsMoving)
        {
            _animator.SetBool("IsIdle", false);
            _animator.SetBool("IsWalking", true);
            // _animator.SetBool("IsJumping", false);
        }
    }
}
