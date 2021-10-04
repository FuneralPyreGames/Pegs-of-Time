using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHandler : MonoBehaviour
{
    public DialogueObject startingDialogueObject;
    public GameObject movementPoint;
    public DialogueManager dialogueManager;
    public void StartDialogue()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        dialogueManager.StartDialogue(startingDialogueObject);
        dialogueManager.SetNPCToMove(gameObject);
    }
    public void MovePosition()
    {
        gameObject.transform.position = movementPoint.transform.position;
    }
}
