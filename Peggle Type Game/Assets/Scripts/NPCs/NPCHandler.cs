using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NPCHandler : MonoBehaviour
{
    public DialogueObject dialogueObject;
    void Start()
    {
        StartCoroutine(Wait2Secs());
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogueObject);
    }
    IEnumerator Wait2Secs()
    {
        yield return new WaitForSeconds(1);
        TriggerDialogue();
    }
}
