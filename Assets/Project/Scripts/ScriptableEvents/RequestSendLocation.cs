using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu( menuName = " Events / Location Request And Send ")]
public class RequestSendLocation : ScriptableObject
{
    public UnityAction onRequestLocation;
    public UnityAction<GameObject> onSendLocation;
    public void RequestLocation(){onRequestLocation?.Invoke();}
    public void SendLocation(GameObject obj){onSendLocation?.Invoke(obj);}
}
