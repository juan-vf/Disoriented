using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEventController : MonoBehaviour
{
    private static SceneEventController _current;
    private void Awake() {
        _current = this;
    }
    public event Action onLoadWinScene;
    public event Action onLoadLooseScene;
    public void LoadWinScene(){onLoadWinScene?.Invoke();}
    public void LoadLooseScene(){onLoadLooseScene?.Invoke();}
    public static SceneEventController GetCurrent{get{return _current;}}
}
