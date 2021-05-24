using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    private Queue<string> sentences;
    public bool isChatting = false;

    public AudioSource seAudioSource;
    public AudioClip seAudioClip;

    private void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue , string name)
    {
        seAudioSource.PlayOneShot(seAudioClip);
        animator.SetBool("isOpen", true);
        nameText.text = name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
        isChatting = true;
    }

    public void DisplayNextSentence()
    {
        seAudioSource.PlayOneShot(seAudioClip);
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        
        animator.SetBool("isOpen", false);
        isChatting = false;
    }

}
