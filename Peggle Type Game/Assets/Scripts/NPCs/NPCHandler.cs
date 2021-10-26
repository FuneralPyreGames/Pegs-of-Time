using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHandler : MonoBehaviour
{
    public DialogueObject startingDialogueObject;
    public DialogueObject ifCompleteDialogueObject;
    public DialogueObject onCompleteDialogueObject;
    public GameObject movementPoint;
    public DialogueManager dialogueManager;
    public void StartDialogue() //This starts dialogue when the player is first interacting with an NPC
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        dialogueManager.StartDialogue(startingDialogueObject);
        dialogueManager.SetNPCToMove(gameObject);
    }
    public void StartIfCompleteDialogue() //This starts dialogue if the event has been completed in a previous run, as marked by ____Save in Persistent Data
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        dialogueManager.StartDialogue(ifCompleteDialogueObject);
        dialogueManager.SetNPCToMove(gameObject);
    }
    public void StartOnCompleteDialogue() //This starts dialogue when the player is returning from a Pachinko level
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        dialogueManager.StartDialogue(onCompleteDialogueObject);
        dialogueManager.SetNPCToMove(gameObject);
    }
    public void MovePosition()
    {
        LeanTween.move(gameObject, movementPoint.transform.position, 1.25f);
    }
}
