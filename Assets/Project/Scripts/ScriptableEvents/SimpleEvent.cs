using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu( menuName = " Events / Simple Event ")]
public class SimpleEvent : ScriptableObject
{
    public UnityAction OnLaunchSimpleEvent;
    public void LaunchSimpleEvent(){OnLaunchSimpleEvent?.Invoke();}
}
