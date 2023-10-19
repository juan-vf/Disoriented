using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieAnimatorController : MonoBehaviour
{
    private Animator _animator;
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
    public void SetMovement(int move)
    {
        _animator.SetInteger(_movement, move);
    }
    public void SetIsTransporting(bool value)
    {
        _animator.SetBool(_isTransporting, value);
    }
    public void SetIsSearching(bool value)
    {
        _animator.SetBool(_isSearching, value);
    }

}
