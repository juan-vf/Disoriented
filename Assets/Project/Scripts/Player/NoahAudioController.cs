using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoahAudioController : MonoBehaviour
{
    [SerializeField]private AudioSource _audioSource;
    [SerializeField]private NoahController _noahController;
    [SerializeField]private NoahAudios _audiosBox;
    [SerializeField]private EventWithVariables _audioCaller;
    // Start is called before the first frame update
    private bool _isPlay = false;
    void Start()
    {
        if(_audioSource == null){_audioSource = GetComponent<AudioSource>();}
        if(_noahController == null){_noahController = GetComponent<NoahController>();}
        _audioCaller.OnEventAudioClip += PlayAudio;
        _audioCaller.OnEventInt += StopAudio;
    }

    // Update is called once per frame
    void Update()
    {
        // if(_noahController.GetMovementComponent.GetVelocity != Vector2.zero){
        //     Debug.Log("ESTOOAAA");
        //     _audioSource.clip = _audiosBox.GetRun;
        //     _audioSource.loop = true;
        // }else{
            
        //     _audioSource.loop = false;
        // }
    }
    void PlayAudio(AudioClip clip){
        if(_audioSource.clip == clip){
            Debug.Log("mismo audio");
            return;
        }
        _audioSource.clip = _audiosBox.GetRun;
        _audioSource.loop = true;
        _audioSource.Play();
    }
    void StopAudio(int nada){
        _audioSource.clip = null;
        _audioSource.Stop();
    }
}
