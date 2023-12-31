using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : CharacterBaseComponent
{
    private Rigidbody _rb;
    private Vector2 _climbInput;
    private  Vector3 _input;
    private float _walkSpeed = 3f;
    public MovementComponent(Rigidbody rigidbody){
        _rb = rigidbody;
    }
    public void Move(Vector3 _input){
        Vector3 oldVelo = _rb.velocity;
        Vector3 newVelo = _input * _walkSpeed;
        newVelo.y = oldVelo.y;
        _rb.velocity = newVelo;
        if (_input.sqrMagnitude > 0.01f)
        {
            _rb.transform.forward = _input;
        }
        return;
    }
    public override void Process()
    {
    }
    public override void Restart()
    {
    }
    public override void Start()
    {
    }
    public override void Update()
    {
    }
}