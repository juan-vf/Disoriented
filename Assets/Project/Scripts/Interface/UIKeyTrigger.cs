using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIKeyTrigger : MonoBehaviour
{
    [SerializeField] private UIElementForMechanic _uIElementForMechanic;
    [SerializeField] private EventWithVariables _UIAndTriggerEnter;
    [SerializeField] private SimpleEvent _UIAndTriggerExit;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _UIAndTriggerEnter.EventSO(_uIElementForMechanic);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // if (other.CompareTag("Player"))
        // {
            _UIAndTriggerExit.LaunchSimpleEvent();
        // }
    }
}
