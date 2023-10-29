using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyGarbageController : MonoBehaviour
{
    [SerializeField]
    private Transform _hand;
    [SerializeField]
    private Rigidbody _garbage;
    [SerializeField]
    private float ThrowStrength = 10.0f;
    [SerializeField]
    private Transform TargetTransform; // Transform del punto de destino

    private bool IsGarbageThrowAvailable = true;
    private Vector3 TargetPoint;

    private void Update()
    {
        if (Mouse.current.leftButton.wasReleasedThisFrame && IsGarbageThrowAvailable)
        {
            // Asignar la posición del Transform del punto de destino
            TargetPoint = TargetTransform.position;
            ThrowGarbage();

            IsGarbageThrowAvailable = true;
        }


    }

    private void ThrowGarbage()
    {
        _garbage.transform.position = _hand.position;
        _garbage.isKinematic = false;
        Vector3 throwDirection = TargetPoint - _garbage.transform.position;
        float distance = throwDirection.magnitude;
        float verticalSpeed = Mathf.Sqrt((2 * ThrowStrength * distance) / Mathf.Abs(Physics.gravity.y));
        float horizontalSpeed = distance / (Mathf.Sqrt((2 * distance) / Mathf.Abs(Physics.gravity.y)));

        _garbage.velocity = new Vector3(throwDirection.normalized.x * horizontalSpeed, verticalSpeed, throwDirection.normalized.z * horizontalSpeed);
        IsGarbageThrowAvailable = false;
    }

}

