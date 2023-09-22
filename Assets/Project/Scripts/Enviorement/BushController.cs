using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushController : MonoBehaviour
{
    private bool _playerHide;
    // Start is called before the first frame update
    void Start()
    {
        _playerHide = false;
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerStay(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            _playerHide = true;
            //Lanzar evento para que el enemigo no lo vea
            EnviorementEventsController.GetCurrent.HiddenPlayer(_playerHide);
        }
        _playerHide = false;
    }
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            _playerHide = false;
            //Lanzar evento para que el enemigo no lo vea
            EnviorementEventsController.GetCurrent.HiddenPlayer(_playerHide);
        }
    }
}
