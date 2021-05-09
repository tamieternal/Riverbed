using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private DialogueManager dialogueManager;
    private PlayerMove playerMove;

    private bool isSpeakable = false;


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
                TriggerDialogue();
            }
        }
    }


    public void TriggerDialogue()
    {
        dialogueManager.StartDialogue(dialogue);
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

}
