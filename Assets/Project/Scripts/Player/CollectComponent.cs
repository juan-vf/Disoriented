using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectComponent : CharacterBaseComponent
{

    public GameObject _itemPrefab;
    public override void Process()
    {
    }

    public override void Restart()
    {
        throw new System.NotImplementedException();
    }

    public override void Start()
    {
        throw new System.NotImplementedException();
    }

    public override void Update()
    {
        throw new System.NotImplementedException();
    }
    public void Collect(Rigidbody rigidbody)
    {
        Vector3 rayOrigin = rigidbody.transform.position;
        Vector3 rayDirection = rigidbody.transform.forward;
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, rayDirection, out hit, 2f))
        {
            Debug.Log("Pego el rayo");
            GameObject hitObject = hit.collider.gameObject;
            if (hitObject.CompareTag("Pet"))
            {
                // rigidbody.Instantiate(_itemPrefab, _positionBack.position, Quaternion.identity, _position);
            }
        }
        // Debug.DrawRay(rayOrigin, rayDirection * rangeRaycast, Color.red, 20f);
    }
}
