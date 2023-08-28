using System;
using System.Collections.Generic;
using UnityEngine;

public class ChestEventSystem : MonoBehaviour
{
    public static ChestEventSystem current;
    private void Awake()
    {
        current = this;
    }
    public event Action onGrabPet;
    public event Action<GameObject> onDropPet;
    public void GrabPet()
    {
        if (onGrabPet != null)
        {
            onGrabPet();
        }
    }
    public void DropPet(GameObject prefab)
    {
        if (onDropPet != null)
        {
            onDropPet(prefab);
        }
    }
}
