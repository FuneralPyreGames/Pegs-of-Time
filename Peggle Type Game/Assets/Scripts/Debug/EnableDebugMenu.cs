using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDebugMenu : MonoBehaviour
{
    public GameObject debugTrigger;
    public GameObject debugPrefab;
    public void Exit()
    {
        debugTrigger.SetActive(false);
    }
    public void OpenDebug(){
        Instantiate(debugPrefab, debugPrefab.transform.position, debugPrefab.transform.rotation);
    }
}