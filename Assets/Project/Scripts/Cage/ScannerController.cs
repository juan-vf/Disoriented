using System.Collections;
using UnityEngine;

public class ScannerController : MonoBehaviour
{
    private Vector3 _minScale;
    [SerializeField] private Vector3 _maxScale;
    //public bool repeatable;
    //public float speed = 2f;
    //public float duration = 5f;

    private bool scanning = false;
    [SerializeField] private float scanInterval = 3f; // Intervalo de tiempo entre escaneos
    private float scanTimer = 0.0f;
    [SerializeField] private float scanDuration = 1.5f; // Duración de un escaneo
    private float scanProgress = 0.0f;

    void Start() 
    {
        _minScale = transform.localScale;
    }
    //void FixedUpdate() {
    //    ESCANEAR();

    //}

    void Update()
    {
        if (!scanning) 
        {
            
            // Inicia un nuevo escaneo cuando no se está ejecutando uno actualmente y el temporizador ha terminado
            scanTimer += Time.deltaTime;
            if (scanTimer >= scanInterval)
            {
                StartScan();
            }
        }

        if (scanning)
        {
            // Actualiza el progreso del escaneo
            scanProgress += Time.deltaTime / scanDuration;

            // Aplica el Lerp en función del progreso
            transform.localScale = Vector3.Lerp(_minScale, _maxScale, scanProgress);

            if (scanProgress >= 1.0f)
            {
                // Espera el tiempo del intervalo de escaneo antes de comenzar el siguiente
                scanning = false; // Marca que el escaneo ha terminado
                scanTimer = 0.0f; // Reinicia el temporizador
                scanProgress = 0.0f; // Reinicia el progreso del escaneo

                // Puedes agregar aquí cualquier otro código que desees ejecutar después de cada escaneo
            }
        }
    }

    void StartScan()
    {
        scanning = true;
    }

    //IEnumerator Start()
    //{

    //    _minScale = transform.localScale;
    //    while (repeatable)
    //    {

    //        //yield return RepeatLerp(_minScale, _maxScale, duration);
    //        //repeatable = false;
    //    }
    //}

    //public IEnumerator RepeatLerp(Vector3 a, Vector3 b, float time)
    //{
    //    float i = 0.0f;
    //    float rate = (1.0f / time) * speed;
    //    while (i < 1.0f)
    //    {
    //        i += Time.deltaTime * rate;
    //        transform.localScale = Vector3.Lerp(a, b, i);
    //        yield return null;
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(message: "OnTriggerEnter with" + other.name);
        //if (other.gameObject.CompareTag("Enemy"))
        //{
        //    Debug.Log("Enemy");
        //}

    }
    //void ESCANEAR()
    //{
    //    float scanTime = 1f;
    //    //float rate = (1.0f / scanTime) * speed;
    //    //i += Time.deltaTime * rate;
    //    //transform.localScale = Vector3.Lerp(_minScale, _maxScale, i*3);
    //    // Comprobar si el tiempo de duración del scanner ha transcurrido
    //    if (Time.time >= scanTime)
    //    {
    //        // Reiniciar el número de veces que se ha ejecutado el scanner
    //        Debug.Log("A");
    //        i = 0;

    //        // Volver a ejecutar la función `ESCANEAR()`
    //        ESCANEAR();
    //    }

    //    // Interpolar el escalado
    //    transform.localScale = Vector3.Lerp(_minScale, _maxScale, i * 3);
    //    Debug.Log("DESPUES DEL LERP");

    //    // Incrementar el contador
    //    i++;
    //}
}