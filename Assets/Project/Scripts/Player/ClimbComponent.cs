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
    private float _desiredDistance = .35f;
    private Vector3 _y;
    private LayerMask _layerMask;
    public ClimbComponent(Rigidbody rigidbody, Vector3 y, LayerMask layerMask)
    {
        _rb = rigidbody;
        _y = y;
        _layerMask = layerMask;
    }
    public void Climb(Vector2 input)
    {
        Debug.DrawLine(_rb.transform.position + _rb.transform.TransformDirection(Vector2.up * 0.9f), _rb.transform.position + (_rb.transform.TransformDirection(Vector2.up * 0.9f)) + _rb.transform.forward * 0.8f, Color.black);


        _finishClimbing = false;
        _climbSpeed = 1.5f;
        //LANZO RAYO PARA SABER LA NORMAL DE LA PARED
        RaycastHit wallPoint; 
        RaycastHit wallUp;
        //ESTE IF SE EJECUTA SIEMPRE Y EMNTONCES SUBE SOLO(SIEMPRE BUSCA ACTUALIZAR LA POSICION PERO EL RAYO NO ESTA EN LOS PIES ENTONCES SIEMPRE SUBE)
        if (Physics.Raycast(
            _rb.transform.position + _rb.transform.TransformDirection(Vector2.up * 0.5f),
            _rb.transform.forward,
            out wallPoint,
            .8f, _layerMask.value))
        {
            _rb.transform.forward = -wallPoint.normal;
        }
        if (!Physics.Raycast(
            _rb.transform.position + _rb.transform.TransformDirection(Vector2.up * 0.9f),
            _rb.transform.forward,
            out wallUp,
            .8f, _layerMask.value))
        {
            //PARA ARREGLAR: CUANDO ESTA PEGADO A LA PARED Y LLEGA AL FINAL DA EL INPULTO PERO LA CAPSULA INPIDE SUBIR PORQUE CHOCA CON LA SUPERFICIE
            _rb.AddForce(Vector3.up * 6.5f, ForceMode.Impulse);
            _finishClimbing = true;
        }
        _rb.velocity = _rb.transform.TransformDirection(input.normalized * _climbSpeed);


    }
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
