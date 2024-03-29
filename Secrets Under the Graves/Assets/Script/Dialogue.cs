using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{

    public string _name;

    public Sprite _spriteBackground;

    public GameObject _firstChoice;
    public GameObject _secondChoice;
    public GameObject _thirdChoice;

    [TextArea(3, 10)]
    public string[] _sentences;

}