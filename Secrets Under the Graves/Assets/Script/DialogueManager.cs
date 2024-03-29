using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public GameObject _background;

    public TMP_Text _nameText;
    public TMP_Text _dialogueText;

    public GameObject _firstChoiceText;
    public GameObject _secondChoiceText;
    public GameObject _thirdChoiceText;

    private Queue<string> _sentences;


    [SerializeField] private Animator _animator;
    [SerializeField] private Animator _animatorTransition;

    void Start()
    {
        Instance = this;
        _sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        _animatorTransition.SetBool("Transition", !_animatorTransition.GetBool("Transition"));
        _animatorTransition.SetBool("Transition", !_animatorTransition.GetBool("Transition"));
        _animator.SetBool("Box", !_animator.GetBool("Box"));
        _nameText.text = dialogue._name;
        _sentences.Clear();

        foreach (string sentence in dialogue._sentences)
        {
            _sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (_sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = _sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        _dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            _dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }

    void EndDialogue()
    {
        _animator.SetBool("Box", !_animator.GetBool("Box"));  
    }
}
