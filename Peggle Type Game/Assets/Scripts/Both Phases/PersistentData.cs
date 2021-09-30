using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    public string PreviousLevel;
    public Vector3 positionToLoadIn;
    public Vector3 cameraPos;
    public GameObject Player;
    public GameObject mainCamera;
    public bool comingFromPachinko1 = false;
    void Awake()
    {
       DontDestroyOnLoad(gameObject); 
    }

    public void PickLoadSpot(string LastLevel)
    {
        switch (LastLevel){
            case "Pachinko Level 1":
                StartCoroutine(WaitToMoveCamera());
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
}
