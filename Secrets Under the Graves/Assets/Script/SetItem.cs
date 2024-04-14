using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetItem : MonoBehaviour
{
    public bool _bone = false;
    public bool _piles = false;
    public bool _key = false;

    public static SetItem Instance;

    public void Awake()
    {
        Instance = this;
    }

    public void SetKey()
    {
        _key = true;
        DialogueTrigger.Instance.TriggerDialogue();
    }

    public void SetBone()
    {
        _bone = true;
        DialogueTrigger.Instance.TriggerDialogue();
    }

    public void SetPiles()
    {
        _piles = true;
        DialogueTrigger.Instance.TriggerDialogue();
    }
}
