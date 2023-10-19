using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCamera : MonoBehaviour
{
    [SerializeField]private Transform _cameraTransform;
    // Start is called before the first frame update

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_cameraTransform.position + (Vector3.left * 11));
        
    }
    public void SetCamera(Transform camera){
        _cameraTransform = camera;
    }
}
