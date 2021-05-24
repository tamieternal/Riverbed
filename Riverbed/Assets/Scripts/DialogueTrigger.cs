using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue[] dialogues;
    private DialogueManager dialogueManager;
    private PlayerMove playerMove;

    private bool isSpeakable = false;

    private Dialogue dialogue;
    public string charaName;

    public void Start()
    {

        playerMove = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();

        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Submit") && isSpeakable)
        {


            if (dialogueManager.isChatting)
            {
                MoveDialogue();

            }
            else
            {
                SelectDialogue();
                TriggerDialogue();
            }
        }
    }


    public void TriggerDialogue()
    {
        dialogueManager.StartDialogue(dialogue,charaName);
    }
    public void MoveDialogue()
    {
        dialogueManager.DisplayNextSentence();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !other.isTrigger && playerMove.lookingNPC == this.gameObject)
        {
            isSpeakable = true;

            

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isSpeakable = false;

        if (other.gameObject.CompareTag("Player") && !other.isTrigger)
        {
            dialogueManager.EndDialogue();

        }
    }


    private void SelectDialogue()
    {
        
        int i = Random.Range(0, dialogues.Length);
        dialogue = dialogues[i];
    }

}
