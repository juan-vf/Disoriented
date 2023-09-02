using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    private static PlayerInputManager _current;
    private PlayerInput _playerInput;
    private Vector2 _move;
    private void Awake() {
        _current = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        _move = _playerInput.actions["Move"].ReadValue<Vector2>();
    }
    public PlayerInputManager getCurrent{get{return _current;}}
    public Vector2 getMove{get{return _move;}}
}
