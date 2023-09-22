using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBaseComponent
{
    public abstract void Start();
    public abstract void Update();
    public abstract void Process();
    public abstract void Restart();
}
