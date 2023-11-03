using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = " UISO / SpriteAndString ")]
public class UIElementForMechanic : ScriptableObject
{
    [SerializeField]private string _text;
    [SerializeField]private Sprite _image;
    public String GetText{get{return _text;}}
    public Sprite GetSprite{get{return _image;}}
}
