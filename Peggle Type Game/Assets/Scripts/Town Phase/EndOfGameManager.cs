using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfGameManager : MonoBehaviour
{
    public DialogueObject dialogueObject;
    public GameObject Car;
    public GameObject Blackout;
    public SceneChangeManager sceneChangeManager;
    void Awake()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogueObject);
    }
    public void EndingCutscene()
    {
        Car = GameObject.Find("Car");
        Blackout = GameObject.Find("Blackout/Blackout Panel");
        StartCoroutine(EndingCutsceneCoroutine());
    }
    IEnumerator EndingCutsceneCoroutine()
    {
        yield return new WaitForSeconds(.5f);
        LeanTween.moveX(Car, 6.05f, 1.5f);
        yield return new WaitForSeconds(.75f);
        LeanTween.scale(Blackout, new Vector3(1.2f,1.2f,1.2f), 0.375f);
        yield return new WaitForSeconds(.375f);
        sceneChangeManager = GameObject.Find("SceneChangeManager(Clone)").GetComponent<SceneChangeManager>();
        sceneChangeManager.LoadTheEnd();
    }
}
