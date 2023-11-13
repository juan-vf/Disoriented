using UnityEngine;

public class AudioControllerClase : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    // [SerializeField] private NoahController _noahController;
    // [SerializeField] private AudioBox _audiosBox;
    [SerializeField] private EventWithVariables _audioCaller;
    private void Start()
    {
        _audioCaller.OnEventAudioClip += PlayAudio;
        _audioCaller.OnEventInt += StopAudio;
    }

    void PlayAudio(AudioClip clip)
    {
        if(_audioSource == null){return;}
        if (_audioSource.clip == clip)
        {
            // Debug.Log("mismo audio");
            return;
        }
        _audioSource.clip = clip;
        _audioSource.loop = true;
        _audioSource.Play();
    }
    void StopAudio(int nada)
    {
        if(_audioSource == null){return;}
        _audioSource.clip = null;
        _audioSource.Stop();
    }
}
