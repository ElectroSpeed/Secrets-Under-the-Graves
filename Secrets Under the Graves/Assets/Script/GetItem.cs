using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    public void GetKey()
    {
        if (SetItem.Instance._key)
        {
            DialogueTrigger.Instance.TriggerDialogue();
        }
    }

    public void GetBone()
    {
        if (SetItem.Instance._bone)
        {
            GetEnds.Instance.SetDogFriend();
        }
    }

    public void GetPiles()
    {
        if (SetItem.Instance._piles)
        {
            GetEnds.Instance.SetDraculaVictory();
        }
    }
}
