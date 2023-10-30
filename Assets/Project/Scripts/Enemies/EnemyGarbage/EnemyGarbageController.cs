using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyGarbageController : MonoBehaviour
{
    [SerializeField]
    private Transform _hand;
    [SerializeField]
    private Rigidbody _garbagePrefab; 
    [SerializeField]
    private float _throwStrength = 20.0f;
    [SerializeField]
    private Transform[] _targetTransforms;
    

    private bool IsGarbageThrowAvailable = true;
    private Transform _lastTargetTransform;

    [SerializeField]
    private GameObject _targetMarker;

    [SerializeField]
    private float _timeBetweenShoot = 3f;
    
    private float _timeShot = 0f;


    private void Update()
    {

        _timeShot += Time.deltaTime;
        Debug.Log(_timeShot);
        if (_timeShot >= _timeBetweenShoot)
        { 

            Transform randomTarget = GetRandomTarget();

            // Lanzar la basura hacia la posición aleatoria
            ThrowGarbage(randomTarget);

            _targetMarker.transform.position = randomTarget.position;
            _targetMarker.SetActive(true);

            //IsGarbageThrowAvailable = true;
            _timeShot = 0f;
            
        }



    }

    private Transform GetRandomTarget()
    {
        // Elegir una posición aleatoria del array de puntos de destino
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, _targetTransforms.Length);
        } while (_targetTransforms[randomIndex] == _lastTargetTransform);

        _lastTargetTransform = _targetTransforms[randomIndex];
        return _lastTargetTransform;
    }

    private void ThrowGarbage(Transform targetTransform)
    {
        // Crear una instancia del prefab del objeto que lanzarás
        Rigidbody garbage = Instantiate(_garbagePrefab, _hand.position, Quaternion.identity);

        // Calcular la dirección hacia el punto de destino
        Vector3 throwDirection = targetTransform.position - garbage.transform.position;

        // Calcular la velocidad inicial en función de la dirección y la fuerza de lanzamiento
        float distance = throwDirection.magnitude;
        float verticalSpeed = Mathf.Sqrt((2 * _throwStrength * distance) / Mathf.Abs(Physics.gravity.y));
        float horizontalSpeed = distance / (Mathf.Sqrt((2 * distance) / Mathf.Abs(Physics.gravity.y)));

        // Aplicar la velocidad inicial al objeto
        garbage.velocity = new Vector3(throwDirection.normalized.x * horizontalSpeed, verticalSpeed, throwDirection.normalized.z * horizontalSpeed);

        Destroy(garbage.gameObject, 5f);
    }

}

