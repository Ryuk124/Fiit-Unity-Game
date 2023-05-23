using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> sentences;
    public bool IsInDialogue;
    public TMP_Text Name;
    public TMP_Text DialogueText;
    public Canvas DialogueCanvas;
    public Animator animator;


    void Start()
    {
        sentences = new Queue<string>();
    }

    void Update()
    {
        if (IsInDialogue)
        {
            if (Input.GetMouseButtonDown(0))
                DisplayNextSentence();
        }
    }

    public void StartDialogue(DialogueObject dialogue)
    {
        IsInDialogue = true;
        DialogueCanvas.gameObject.SetActive(true);
        animator.SetBool("IsOpen", true);

        Name.text = dialogue.Name;
        sentences.Clear();

        foreach (string sentence in dialogue.Sentences)
            sentences.Enqueue(sentence);

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        var sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    private IEnumerator TypeSentence(string sentence)
    {
        DialogueText.text = "";

        foreach (var letter in sentence.ToCharArray())
        {
            DialogueText.text += letter;
            Thread.Sleep(50);
            yield return null;
        }
    }

    private void EndDialogue()
    {
        IsInDialogue = false;
        animator.SetBool("IsOpen", false);
        DialogueCanvas.gameObject.SetActive(false);
    }
}
