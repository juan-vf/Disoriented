using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateController : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private SimpleEvent _pulleyPetsBox;
    [SerializeField] private SimpleEvent _pulleyPetsBoxUp;
    private Vector3 _firstPosition;
    private Vector3 _posicionFinal;
    private bool bajando = false;
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _firstPosition = transform.position;
        _posicionFinal = _firstPosition + Vector3.down * 10f;
        // _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter(Collision other) {
        if(other.transform.CompareTag("Player")){
            _pulleyPetsBox.LaunchSimpleEvent();
        }
    }
    private void OnCollisionExit(Collision other) {
        if(other.transform.CompareTag("Player")){
            _pulleyPetsBoxUp.LaunchSimpleEvent();
        }
    }
}
