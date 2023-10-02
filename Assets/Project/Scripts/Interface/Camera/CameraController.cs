using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]private CinemachineVirtualCamera _cMVitualCamera;
    // Start is called before the first frame update
    void Start()
    {
        _cMVitualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_cMVitualCamera.transform.position.z  <= -18.0f){
            // _cMVitualCamera.ForceCameraPosition(new Vector3(transform.position.x,transform.position.y,10f), Quaternion.identity);
            // Debug.Log(_cMVitualCamera.transform.position.z + "" +  transform.position.z);
            _cMVitualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_CameraDistance = 6f;
        }
        else{
             _cMVitualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_CameraDistance = 14.6f;
        }
    }
}
