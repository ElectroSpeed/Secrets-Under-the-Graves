using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public GameObject _transition;
    
    public Image _background;

    public GameObject _backText;

    public TMP_Text _nameText;
    public TMP_Text _dialogueText;

    public Transform _parentChoiceText;
    public Transform _parentOutText;

    private Queue<string> _sentences;

    private Dialogue _dialogue;


    [SerializeField] private Animator _animator;
    [SerializeField] private Animator _animatorTransition;

    void Start()
    {
        Instance = this;
        _sentences = new Queue<string>();
        _backText.SetActive(true);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        if (_dialogue != null)
        {
            EndDialogue();
        }
        StartCoroutine(FirstDialogue(dialogue));
    }

    private IEnumerator FirstDialogue(Dialogue dialogue)
    {
        _animator.SetTrigger("BoxIn");
        yield return new WaitForSeconds(1.8f);
        if (_background != null)
        {
            _background.sprite = dialogue._spriteBackground;
        }
        yield return new WaitForSeconds(1.2f);
        _transition.SetActive(false);
        _dialogue = dialogue;
        _nameText.text = dialogue._name;
        _sentences.Clear();

        foreach (string sentence in dialogue._sentences)
        {
            _sentences.Enqueue(sentence);
        }
        if (_dialogue._choice.Count != 0)
        {
            foreach (GameObject choice in dialogue._choice)
            {
                choice.transform.SetParent(_parentChoiceText);
            }
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (_sentences.Count == 1)
        {
            _backText.SetActive(false);
            foreach (GameObject choice in _dialogue._choice)
            {
                choice.SetActive(true);
            }
        }
        else
        {
            _backText.SetActive(true);
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

    public void EndDialogue()
    {
        _transition.SetActive(true);
        _animator.SetTrigger("BoxOut");
        _animatorTransition.SetTrigger("Transition");
        foreach (GameObject choice in _dialogue._choice)
        {
            choice.SetActive(false);
            choice.transform.SetParent(_parentOutText);
        }
    }
}
