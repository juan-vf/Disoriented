using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandpaController : MonoBehaviour
{
    [SerializeField] private bool _isEnable = false;
    [SerializeField] private GameObject _scanner;
    [SerializeField] private float _timerScanner = 3f;
    private float _timeStartScanner;
    void Start()
    {
        _scanner.SetActive(false);
        EnemieManagmentEvent.GetCurrent.onEnableScanner += EnableScanner;
        // Si quisiera ejecutarlo apenas me suscribo lo llamo con ()
        
    }

    // Update is called once per frame
    void Update()
    {
        _timeStartScanner += Time.deltaTime;

        if (_timeStartScanner >= _timerScanner && _isEnable)
        {

                _scanner.SetActive(false);  
                _scanner.SetActive(true);
                _timeStartScanner = 0f;
        }
    }
    // pasar parametro por referencia
    void EnableScanner()
    { 
        // activar scanner.
        _isEnable = true;        
    }


}
