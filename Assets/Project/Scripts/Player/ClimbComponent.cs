using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbComponent : CharacterBaseComponent
{
    private Rigidbody _rb;
    private float _climbSpeed = 1.5f;
    private bool _jumping = false;
    private bool _finishClimbing = false;
    private Vector3 _wallPoint;
    public ClimbComponent(Rigidbody rigidbody)
    {
        _rb = rigidbody;
    }
    public void Climb(Vector2 input)
    {
        _finishClimbing = false;
        //LANZO RAYO PARA SABER LA NORMAL DE LA PARED
        RaycastHit wallPoint;
        // Physics.Raycast(
        //     _rb.transform.position + _rb.transform.TransformDirection(Vector2.up * 0.5f),
        //     _rb.transform.forward,
        //     out wallPoint,
        //     1.3f);
        //ESTE IF SE EJECUTA SIEMPRE Y EMNTONCES SUBE SOLO(SIEMPRE BUSCA ACTUALIZAR LA POSICION PERO EL RAYO NO ESTA EN LOS PIES ENTONCES SIEMPRE SUBE)
        if (Physics.Raycast(
            _rb.transform.position + _rb.transform.TransformDirection(Vector2.up * 0.5f),
            _rb.transform.forward,
            out wallPoint,
            1.3f))
        {

            _rb.transform.forward = -wallPoint.normal;

            // if (!Physics.Raycast(_rb.transform.position, _rb.transform.forward, 1.3f))
            // {
            //     _rb.velocity = input * 20f;
            //     Debug.Log("ACAAAAnoooooooooo");
            // }
            // else
            // {
            //     _rb.velocity = Vector3.zero;
            // }
        }else{

            Debug.Log("Ya llega");

            _climbSpeed = 3f;
            _rb.velocity = Vector3.up * 5f;
            _finishClimbing = true;
        }
        _rb.velocity = _rb.transform.TransformDirection(input.normalized * _climbSpeed);

        
    }

    // public void Climb(Vector3 input)
    // {
    //     // Rigidbody rb = noahStateMachineManager.GetRigidbody;
    //     Vector3 offset = _rb.transform.TransformDirection(Vector2.one * 0.5f);
    //     Vector3 checkDirection = Vector3.zero;
    //     int k = 0;
    //     for (int i = 0; i < 4; i++)
    //     {
    //         RaycastHit checkHit;
    //         if (Physics.Raycast(_rb.transform.position + offset,
    //                             _rb.transform.forward,
    //                             out checkHit, 2f))
    //         {
    //             checkDirection += checkHit.normal;
    //             k++;
    //         }
    //         // Rotate Offset by 90 degrees
    //         offset = Quaternion.AngleAxis(90f, _rb.transform.forward) * offset;
    //         _finishClimbing = false;
    //     }
    //     checkDirection /= k;

    //     RaycastHit hit;
    //     if (Physics.Raycast(_rb.transform.position, -checkDirection, out hit))
    //     {
    //         _finishClimbing = false;
    //         // // float dot = Vector3.Dot(_rb.transform.forward, -hit.normal);
    //         // Debug.Log(hit.normal + "" + hit.point);
    //         // float sum = _rb.position.y + hit.point.y;
    //         // Vector3 ac = new Vector3(_rb.position.x, -sum, _rb.position.z);
    //         _rb.position = Vector3.Lerp(_rb.transform.position,
    //                                     hit.point + hit.normal * 0.51f,
    //                                     10f * Time.fixedDeltaTime);
    //         _rb.transform.forward = -hit.normal;
    //         /*Vector3.Lerp(
    //                                         _rb.transform.forward,
    //                                         -hit.normal,
    //                                         10f * Time.fixedDeltaTime
    //                                         );*/
    //         // rb.useGravity = false;
    //         _rb.velocity = _rb.transform.TransformDirection(input) * _climbSpeed;
    //         if (PlayerInputManager.getCurrent.getIsJumping)
    //         {

    //             _jumping = PlayerInputManager.getCurrent.getIsJumping;
    //         }
    //     }else{
    //         _rb.velocity = Vector3.up;
    //         _finishClimbing = true;
    //     }

    // }
    public bool getFinishClimbing { get { return _finishClimbing; } set { _finishClimbing = value; } }
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
