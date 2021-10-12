using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownManager : MonoBehaviour
{
    public PersistentData persistentData;
    public LoopManager loopManager;
    private void Awake()
    {
        StartCoroutine(WaitToStartLoop());

    }
    private void CheckLoopState()
    {
        loopManager = GameObject.Find("Loop Manager").GetComponent<LoopManager>();
        if (persistentData.loopOn == false){
            loopManager.StartLoop();
        }
    }
    IEnumerator WaitToStartLoop()
    {
        yield return new WaitForSeconds(0.05f);
        persistentData = GameObject.Find("PersistentData(Clone").GetComponent<PersistentData>();
        CheckLoopState();
    }
}
