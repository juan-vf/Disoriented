using UnityEngine;

[CreateAssetMenu( menuName = "Audio / Noah Clips")]
public class NoahAudios : ScriptableObject
{
    [Header("Audio Clips")]
    [SerializeField]private AudioClip SaveInBackpack;
    public AudioClip GetSaveInBackPack{get{return SaveInBackpack;}}
    [SerializeField]private AudioClip runClip;
    public AudioClip GetRun{get{return runClip;}}
}
