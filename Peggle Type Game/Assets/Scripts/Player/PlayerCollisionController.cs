using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    public PersistentData persistentData;
    public void DetermineTriggerAction(Collider2D collision)
    {
        if (collision.name == "Mallory"){
            persistentData = GameObject.Find("PersistentData(Clone)").GetComponent<PersistentData>();
            if (persistentData.pachinkoLevel2Done == false){
                collision.GetComponent<NPCHandler>().StartDialogue();
            }
            else if (persistentData.pachinkoLevel2Done == true){
                if (persistentData.mallorySave == false){
                    collision.GetComponent<NPCHandler>().StartOnCompleteDialogue();
                }
                else if (persistentData.mallorySave == true){
                    if (persistentData.malloryHelped == false){
                        collision.GetComponent<NPCHandler>().StartIfCompleteDialogue();
                    }
                }
            }
            else if (persistentData.mallorySave == true)
            {
                collision.GetComponent<NPCHandler>().StartIfCompleteDialogue();
            }
        }
        else if (collision.name == "Gregory")
        {
            persistentData = GameObject.Find("PersistentData(Clone)").GetComponent<PersistentData>();
            if (persistentData.pachinkoLevel3Done == false)
            {
                collision.GetComponent<NPCHandler>().StartDialogue();
            }
            else if (persistentData.pachinkoLevel3Done == true)
            {
                if (persistentData.gregorySave == false)
                {
                    collision.GetComponent<NPCHandler>().StartOnCompleteDialogue();
                }
                else if (persistentData.gregorySave == true)
                {
                    if (persistentData.gregoryHelped == false)
                    {
                        collision.GetComponent<NPCHandler>().StartIfCompleteDialogue();
                    }
                }
            else if (persistentData.gregorySave == true)
            {
                collision.GetComponent<NPCHandler>().StartIfCompleteDialogue();
            }
            }
        }
        else if (collision.name == "Dexter")
        {
            persistentData = GameObject.Find("PersistentData(Clone)").GetComponent<PersistentData>();
            if (persistentData.pachinkoLevel4Done == false)
            {
                collision.GetComponent<NPCHandler>().StartDialogue();
            }
            else if (persistentData.pachinkoLevel4Done == true)
            {
                if (persistentData.dexterSave == false)
                {
                    collision.GetComponent<NPCHandler>().StartOnCompleteDialogue();
                }
                else if (persistentData.dexterSave == true)
                {
                    if (persistentData.dexterHelped == false)
                    {
                        collision.GetComponent<NPCHandler>().StartIfCompleteDialogue();
                    }
                }
            else if (persistentData.dexterSave == true)
            {
                collision.GetComponent<NPCHandler>().StartIfCompleteDialogue();
            }
            }
        }
        else if (collision.name == "Axel")
        {
            persistentData = GameObject.Find("PersistentData(Clone)").GetComponent<PersistentData>();
            if (persistentData.pachinkoLevel5Done == false)
            {
                collision.GetComponent<NPCHandler>().StartDialogue();
            }
            else if (persistentData.pachinkoLevel5Done == true)
            {
                if (persistentData.axelSave == false)
                {
                    collision.GetComponent<NPCHandler>().StartOnCompleteDialogue();
                }
                else if (persistentData.axelSave == true)
                {
                    if (persistentData.axelHelped == false)
                    {
                        collision.GetComponent<NPCHandler>().StartIfCompleteDialogue();
                    }

                }
            }
            else if (persistentData.axelSave == true)
            {
                collision.GetComponent<NPCHandler>().StartIfCompleteDialogue();
            }
        }
        else if (collision.name == "Beth"){
            collision.GetComponent<NPCHandler>().StartDialogue();
        }
        else if (collision.name == "Noah"){
            collision.GetComponent<NPCHandler>().StartDialogue();
        }
        else if (collision.name == "Roman"){
            persistentData = GameObject.Find("PersistentData(Clone)").GetComponent<PersistentData>();
            if (persistentData.pachinkoLevel6Done == true){
                collision.GetComponent<NPCHandler>().StartOnCompleteDialogue();
            }
            else{
                collision.GetComponent<NPCHandler>().StartDialogue();
            }
        }

    }
}
