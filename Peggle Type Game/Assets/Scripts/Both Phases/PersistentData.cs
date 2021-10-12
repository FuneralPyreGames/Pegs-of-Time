using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    #region Variables
    public string PreviousLevel;
    public Vector3 positionToLoadIn;
    public Vector3 cameraPos;
    public GameObject Player;
    public GameObject mainCamera;
    public bool loopOn = false;
    public bool comingFromPachinko1 = false;
    public bool pachinkoLevel2Done = false;
    public bool malloryHelped = false;
    public bool mallorySave = false;
    public bool pachinkoLevel3Done = false;
    public bool gregoryHelped = false;
    public bool gregorySave = false;
    #endregion
    void Awake()
    {
       DontDestroyOnLoad(gameObject); 
    }

    public void PickLoadSpot(string LastLevel)
    {
        switch (LastLevel){
            case "Start Of Town":
                StartCoroutine(WaitToMoveCamera());
                break;
            case "Pachinko Level 2":
                StartCoroutine(GiveLoadingTime());
                break;
            case "Pachinko Level 3":
                StartCoroutine(GiveLoadingTimeL3());
                break;
        }
    }
    IEnumerator WaitToMoveCamera()
    {
        yield return new WaitForSeconds(0.5f);
        cameraPos = new Vector3(95, 3, -10f);
        mainCamera = GameObject.Find("Main Camera");
        LeanTween.move(mainCamera, cameraPos, .00000001f);
    }
    IEnumerator GiveLoadingTime()
    {
        yield return new WaitForSeconds(0.25f);
        Player = GameObject.Find("Player");
        Player.transform.position = new Vector3(60.17466f, 29.705f, 1);
    }
    IEnumerator GiveLoadingTimeL3()
    {
        yield return new WaitForSeconds(0.25f);
        Player = GameObject.Find("Player");
        Player.transform.position = new Vector3(-0.1145606f, -26.14114f, 1);
    }
}
