using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageController : MonoBehaviour
{
    [SerializeField] private bool _isTrue = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isTrue)
        { 
            EnemieManagmentEvent.GetCurrent.EnableScanner();
            _isTrue = false;
        }

        
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("Collision");
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("Trigger");
    //}

}
