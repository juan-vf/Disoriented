using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyUIManager : MonoBehaviour
{
    [SerializeField]private EventWithVariables _UIAndTriggerEnter;
    [SerializeField]private SimpleEvent _UIAndTriggerExit;
    [SerializeField]private Image _image;
    [SerializeField]private float _animationTime = 2f;
    [SerializeField]private float _time = 0f;
    [SerializeField]private float _finalScale = 1.5f;
    private Vector3 _localScale;
    private bool _animate;
    void Start()
    {
        _image = GetComponent<Image>();

        _image.color = new Color(0,0,0,0);
        _localScale = _image.transform.localScale;

        _UIAndTriggerEnter.OnEventSO += SetUIElement;
        _UIAndTriggerExit.OnLaunchSimpleEvent += DisableUIElement;

    }
    private void Update() {
        //SI LA ESCALA ACTUAL ES IGUAL A LA QUE SE ESPERA SE REGRESA A LA ORIGINAL
    }
    void SetUIElement(UIElementForMechanic SO){
        if(_image != null){
            _image.color = new Color(255,255,255,255);
            _image.sprite = SO.GetSprite;
        }
    }
    void DisableUIElement(){
        if(_image != null){
            _image.color = new Color(0,0,0,0);
        }
    }
}
