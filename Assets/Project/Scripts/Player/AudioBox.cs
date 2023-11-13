using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = "Audio / Box")]
public class AudioBox : ScriptableObject
{
    // [Header("Character Information")]
    // public string characterName;

    [Header("Audio Clips")]
    // public AudioClip idleClip;
    public AudioClip runClip;
    // public AudioClip attackClip;
    public AudioClip GetRun{get{return runClip;}}
}
