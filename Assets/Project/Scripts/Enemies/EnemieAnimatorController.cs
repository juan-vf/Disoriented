using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemieAnimatorController : MonoBehaviour
{
    [SerializeField]private Animator _animator;
    private int _movement;
    private int _isTransporting;
    private int _isSearching;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();

        _movement = Animator.StringToHash("FMovement");
        _isTransporting = Animator.StringToHash("FIsTransporting");
        _isSearching = Animator.StringToHash("FIsSearching");

        //SET INITIALS VALUES
        SetIsTransporting(false);
        SetIsSearching(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public Animator GetAnimator{get{return _animator;}}
    public void SetMovement(float move)
    {
        _animator.SetFloat(_movement, move);
    }
    public void SetIsTransporting(bool value)
    {
        _animator.SetBool(_isTransporting, value);
    }
    public void SetIsSearching(bool value)
    {
        // Debug.Log("Se Seteo IsSearching: "+ value);
        _animator.SetBool(_isSearching, value);
    }

    public float GetAnimationLengthByName(string animationName){
        AnimationClip clip = _animator.runtimeAnimatorController.animationClips.FirstOrDefault(c => c.name == animationName);
        return clip.length;
    }
}
