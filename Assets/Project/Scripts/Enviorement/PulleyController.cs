using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulleyController : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private SimpleEvent _pulleyPetsBox;
    [SerializeField] private SimpleEvent _pulleyPetsBoxUp;
    [Header("Variables")]
    [SerializeField] private float _howMuchDown;
    [SerializeField] private float _timeToDown;
    private bool _IsComingDown = false;
    private bool _IsComingUp = false;
    float tiempoTranscurrido = 0f;
    Vector3 posicionActual;
    // Start is called before the first frame update
    void Start()
    {
        _pulleyPetsBox.OnLaunchSimpleEvent += DownUp;
        _pulleyPetsBoxUp.OnLaunchSimpleEvent += Up;
        // bajarObjeto(transform.position, transform.position + Vector3.down * _howMuchDown, _timeToDown);
        posicionActual = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(_IsComingDown && _IsComingUp == false){
            bajarObjeto(posicionActual, posicionActual + Vector3.down * _howMuchDown, _timeToDown);
            // Debug.Log("bajando");
            // _IsComingDown = false;
            
            if(transform.position == posicionActual + Vector3.down * _howMuchDown){
                _IsComingDown = false;tiempoTranscurrido = 0;
            }
        }
        // if(_IsComingDown && _IsComingUp == false && transform.position != posicionActual + Vector3.down * _howMuchDown){Debug.Log("SE PARO");_IsComingUp = true ; _IsComingDown = false;}
        if(_IsComingUp && _IsComingDown == false){
            // Debug.Log("SUBIO1");
            bajarObjeto(transform.position, posicionActual, _timeToDown);
            if(transform.position == posicionActual){
                _IsComingUp = false;tiempoTranscurrido = 0;
            }
        }
    }
    void DownUp(){_IsComingDown = true; _IsComingUp = false;}
    void Up(){_IsComingUp = true; _IsComingDown = false; Debug.Log(_IsComingUp);}
    public void bajarObjeto(Vector3 posicionInicial, Vector3 posicionFinal, float tiempo)
    {
        Vector3 posicionIntermedia = Vector3.Lerp(posicionInicial, posicionFinal, tiempoTranscurrido / tiempo);
        transform.position = posicionIntermedia;
        tiempoTranscurrido += Time.deltaTime;
        // Debug.Log(posicionIntermedia);
    }

}
