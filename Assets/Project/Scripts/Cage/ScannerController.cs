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
    [SerializeField] private float scanDuration = 1.5f; // Duraci�n de un escaneo
    private float scanProgress = 0.0f;
    private bool _playerIsHidden = false;
    private SphereCollider _scanCollider;
    [SerializeField]private EventWithVariables _grandpaAndScanner;

    void Start() 
    {
        _scanCollider = GetComponent<SphereCollider>();
        EnviorementEventsController.GetCurrent.onHiddenPlayer += HiddenUpdates;
        _minScale = transform.localScale;
    }
    //void FixedUpdate() {
    //    ESCANEAR();

    //}

    void Update()
    {
        if (!scanning) 
        {
            
            // Inicia un nuevo escaneo cuando no se est� ejecutando uno actualmente y el temporizador ha terminado
            scanTimer += Time.deltaTime;
            if (scanTimer >= scanInterval)
            {
                StartScan();
            }
            _scanCollider.enabled = false;
            // _grandpaAndScanner.OnEventFloat(scanInterval);
        }

        if (scanning)
        {
            // Actualiza el progreso del escaneo
            scanProgress += Time.deltaTime / scanDuration;

            // Aplica el Lerp en funci�n del progreso
            transform.localScale = Vector3.Lerp(_minScale, _maxScale, scanProgress);

            if (scanProgress >= 1.0f)
            {
                // Espera el tiempo del intervalo de escaneo antes de comenzar el siguiente
                scanning = false; // Marca que el escaneo ha terminado
                scanTimer = 0.0f; // Reinicia el temporizador

                // Puedes agregar aqu� cualquier otro c�digo que desees ejecutar despu�s de cada escaneo
            }
        }
    }

    void StartScan()
    {
        scanning = true;
        _scanCollider.enabled = true;
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
        if (other.gameObject.CompareTag("Player") && _playerIsHidden == false)
        {
           SceneEventController.GetCurrent.LoadLooseScene();
        }

    }
    void HiddenUpdates(bool hidden){
        _playerIsHidden = hidden;
    }
    //void ESCANEAR()
    //{
    //    float scanTime = 1f;
    //    //float rate = (1.0f / scanTime) * speed;
    //    //i += Time.deltaTime * rate;
    //    //transform.localScale = Vector3.Lerp(_minScale, _maxScale, i*3);
    //    // Comprobar si el tiempo de duraci�n del scanner ha transcurrido
    //    if (Time.time >= scanTime)
    //    {
    //        // Reiniciar el n�mero de veces que se ha ejecutado el scanner
    //        Debug.Log("A");
    //        i = 0;

    //        // Volver a ejecutar la funci�n `ESCANEAR()`
    //        ESCANEAR();
    //    }

    //    // Interpolar el escalado
    //    transform.localScale = Vector3.Lerp(_minScale, _maxScale, i * 3);
    //    Debug.Log("DESPUES DEL LERP");

    //    // Incrementar el contador
    //    i++;
    //}
}