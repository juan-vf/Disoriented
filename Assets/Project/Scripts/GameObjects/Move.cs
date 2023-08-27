using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float _xMovement;
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _xMovement = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate() {
        transform.Translate(new Vector3(_xMovement, 0, 0));
    }
}
