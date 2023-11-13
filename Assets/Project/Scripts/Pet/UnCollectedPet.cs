using UnityEngine;

public class UnCollectedPet : MonoBehaviour
{
    private bool _isPicked;
    private PetController _petController;
    [SerializeField] private bool _enabledToCollect;
    [Header("Events")]
    [SerializeField] private GrabEventManager _noahGrabPet;
    [SerializeField] private GrabEventManager _enemyGrabPet;
    [SerializeField] private EventWithVariables _callAudio;
    // [SerializeField]private AudioBox _audioBox;
    void Start()
    {

        _petController = GetComponent<PetController>();
        PetEventsManager.GetCurrent.onBackPackFull += BackPackUpdates;
        // PetEventsManager.GetCurrent.onDestroyPetById += PickedUpByEnemy;
        // PetEventsManager.GetCurrent.onGrabPet += Picked;
        // PetEventsManager.GetCurrent.onSendPetData += Picked;

        //SOEVENTS
        _noahGrabPet.onGrabPet += PickedByNoah;
        _enemyGrabPet.onGrabPetInHand += PickedUpByEnemy;

        // _callAudio.OnEventAudioClip(_audioBox.GetRun);
    }
    private void Update()
    {
    }
    private void OnCollisionStay(Collision other)
    {
    }
    public void Picked(int id, int serialId)
    {
        if(_petController.GetSerialId == id){

            // PetEventsManager.GetCurrent.SendPetData(_petController.GetId, _petController.GetSerialId);

            // Debug.Log("ME DESTRUYO");
            // transform.gameObject.SetActive(false);
            // Destroy(gameObject);
        }
    }
    private void BackPackUpdates(bool value)
    {
        _enabledToCollect = value;
    }
    void PickedUpByEnemy(int id, Transform hands)
    {
        if (this == null) { return; }
        if (_petController.GetSerialId == id) {
            // gameObject.SetActive(false);
            _enemyGrabPet.SendPetToListener(_petController.GetId, _petController.GetSerialId);
            transform.SetParent(hands);
            transform.localPosition = Vector3.zero;
            transform.GetComponent<CapsuleCollider>().enabled = false;
            transform.GetComponent<Rigidbody>().isKinematic = true;
            // Debug.Log("AGARRADA");
        }
    }
    void PickedByNoah(int value){
        if(_petController.GetSerialId == value){
            if(_petController != null){
                _noahGrabPet.SendPetToListener(_petController.GetId, _petController.GetSerialId);
                // _callAudio.OnEventInt(1);
                gameObject.SetActive(false);
            }
        }
    }
    public bool GetIsPickedUp { get { return _isPicked; } }
}
