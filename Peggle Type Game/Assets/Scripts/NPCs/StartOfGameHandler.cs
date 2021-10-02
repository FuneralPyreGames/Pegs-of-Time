using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StartOfGameHandler : MonoBehaviour
{
    #region Variables
    public DialogueObject dialogueObject;
    public DialogueObject dialogueObject2;
    public DialogueObject dialogueObject3;
    public DialogueObject dialogueObject4;
    public GameObject mainCamera;
    public GameObject Blackout;
    public bool comingFromPachinko1 = false;
    public PersistentData persistentData;
    #endregion
    void Awake()
    {
        StartCoroutine(LoadBlackoutHandler());
    }
    #region DialogueTriggers
    public void TriggerDialogue1()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogueObject);
    }
    public void TriggerDialogue2(){
        FindObjectOfType<DialogueManager>().StartDialogue(dialogueObject2);
    }
    public void TriggerDialogue3(){
        FindObjectOfType<DialogueManager>().StartDialogue(dialogueObject3);
    }
    public void TriggerDialogue4(){
        FindObjectOfType<DialogueManager>().StartDialogue(dialogueObject4);
    }
    #endregion
    #region CoroutineTriggers
    public void StartMoveToScene2Coroutine(){
        StartCoroutine(MoveToScene2());
    }
    public void StartMoveToScene4Coroutine(){
        StartCoroutine(MoveToScene4());
    }
    #endregion
    #region Coroutines
    IEnumerator Wait2Secs()
    {
        yield return new WaitForSeconds(1);
        TriggerDialogue1();
    }
    IEnumerator MoveToScene2()
    {
        yield return new WaitForSeconds(.375f);
        LeanTween.move(mainCamera, new Vector3 (58, 3, -10), .1f);
        yield return new WaitForSeconds(3f);
        LeanTween.scale(Blackout, new Vector3(0,0,0), .4f);
        TriggerDialogue2();
    }
    IEnumerator MoveToScene4()
    {
        yield return new WaitForSeconds(.375f);
        LeanTween.move(mainCamera, new Vector3 (137, 3, -10), .1f);
        yield return new WaitForSeconds(3f);
        LeanTween.scale(Blackout, new Vector3(0,0,0), .4f);
        TriggerDialogue4();
    }
    IEnumerator FailsafeWait()
    {
        yield return new WaitForSeconds(1f);
        persistentData = GameObject.Find("PersistentData(Clone)").GetComponent<PersistentData>();
        comingFromPachinko1 = persistentData.comingFromPachinko1;
        if (comingFromPachinko1 == false)
        {
            StartCoroutine(Wait2Secs());
            persistentData.comingFromPachinko1 = true;
        }
        else if (comingFromPachinko1 == true)
        {
            TriggerDialogue3();
        }
    }
    IEnumerator LoadBlackoutHandler()
    {
        yield return new WaitForSeconds(1f);
        LeanTween.scale(Blackout, new Vector3(0, 0, 0), 1.4f);
        StartCoroutine(FailsafeWait());
    }
    #endregion
}
