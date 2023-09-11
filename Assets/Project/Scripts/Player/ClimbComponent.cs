using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbComponent : CharacterBaseComponent
{
    private Rigidbody _rb;
    private float _climbSpeed = 3f;
    private bool _jumping = false;
    private bool _finishClimbing = false;
    public ClimbComponent(Rigidbody rigidbody){
        _rb = rigidbody;
    }
    public void Climb(Vector3 input)
    {
        // Rigidbody rb = noahStateMachineManager.GetRigidbody;
        Vector3 offset = _rb.transform.TransformDirection(Vector2.one * 0.5f);
        Vector3 checkDirection = Vector3.zero;
        int k = 0;
        for (int i = 0; i < 4; i++)
        {
            RaycastHit checkHit;
            if (Physics.Raycast(_rb.transform.position + offset,
                                _rb.transform.forward,
                                out checkHit))
            {
                checkDirection += checkHit.normal;
                k++;
            }
            // Rotate Offset by 90 degrees
            offset = Quaternion.AngleAxis(90f, _rb.transform.forward) * offset;
        }
        checkDirection /= k;

        RaycastHit hit;
        if (Physics.Raycast(_rb.transform.position, -checkDirection, out hit))
        {
            float dot = Vector3.Dot(_rb.transform.forward, -hit.normal);

            _rb.position = Vector3.Lerp(_rb.position,
                                        hit.point + hit.normal * 0.3f,
                                        5f * Time.fixedDeltaTime);
            _rb.transform.forward = Vector3.Lerp(
                                            _rb.transform.forward,
                                            -hit.normal,
                                            10f * Time.fixedDeltaTime
                                            );
            // rb.useGravity = false;
            _rb.velocity = _rb.transform.TransformDirection(input) * _climbSpeed;
            if (PlayerInputManager.getCurrent.getIsJumping)
            {
                
                _jumping = PlayerInputManager.getCurrent.getIsJumping;
            }
        }else{
            _rb.velocity = Vector3.up;
            _finishClimbing = true;
        }

    }
    public override void Process()
    {
        throw new System.NotImplementedException();
    }

    public override void Restart()
    {
        throw new System.NotImplementedException();
    }

    public override void Start()
    {
        throw new System.NotImplementedException();
    }

    public override void Update()
    {
        throw new System.NotImplementedException();
    }
}
