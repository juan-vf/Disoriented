using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Void Event Channel")]
public class VoidEventChannelSO : ScriptableObject
{
    // Start is called before the first frame update
    public UnityAction OnEventRaised;

    public void RaiseEvent() { OnEventRaised?.Invoke(); }
}
