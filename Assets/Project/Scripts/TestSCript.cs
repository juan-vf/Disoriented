using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TestSCript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("test");   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator test(){
        yield return new WaitForSecondsRealtime(2f);
        transform.position += Vector3.up;
    }
}
