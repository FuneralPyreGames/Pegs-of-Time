using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    public void DetermineTriggerAction(Collider2D collision)
    {
        collision.GetComponent<NPCHandler>().StartDialogue();
    }
}
