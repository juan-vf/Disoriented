using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu( menuName = " Events / With Variables ")]
public class EventWithVariables : ScriptableObject
{
    public UnityAction<int> OnEventInt;
    public UnityAction<float> OnEventFloat;
    public UnityAction<string> OnEventString;
    public UnityAction<float, float> OnEventTwoFloat;
    public UnityAction<UIElementForMechanic> OnEventSO;
    public void EventRaised(int value){OnEventInt?.Invoke(value);}
    public void EventFloat(float value){OnEventFloat?.Invoke(value);}
    public void EventString(string value){OnEventString?.Invoke(value);}
    public void EventTwoFloat(float valueOne,float valueTwo){OnEventTwoFloat?.Invoke(valueOne, valueTwo);}
    public void EventSO(UIElementForMechanic SO){OnEventSO?.Invoke(SO);}
}
