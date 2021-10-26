using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMenu : MonoBehaviour
{
    public GameObject debugMenu;
    public PachinkoData pachinkoData;
    public LoopManager loopManager;
    public PersistentData persistentData;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        if (Input.GetKeyDown("e")){
            debugMenu.SetActive(true);
        }
    }
    public void Exit()
    {
        debugMenu.SetActive(false);
    }
    public void StopTheLoop()
    {
        loopManager = GameObject.Find("LoopManager(Clone)").GetComponent<LoopManager>();
        loopManager.StopLoop();
    }
    public void LoopTimer0()
    {
        loopManager = GameObject.Find("LoopManager(Clone)").GetComponent<LoopManager>();
        loopManager.LoopTimerUp();  
    }
    public void SetEveryoneHelped()
    {
        persistentData = GameObject.Find("PersistentData(Clone)").GetComponent<PersistentData>();
        persistentData.malloryHelped = true;
        persistentData.gregoryHelped = true;
        persistentData.dexterHelped = true;
        persistentData.axelHelped = true;
    }
    public void PachinkoBalls99()
    {
        pachinkoData = GameObject.Find("PachinkoData").GetComponent<PachinkoData>();
        pachinkoData.balls = 99;
        pachinkoData.SetBallCount();
    }
    public void WinLevel()
    {
        pachinkoData = GameObject.Find("PachinkoData").GetComponent<PachinkoData>();
        pachinkoData.Win();
    }
}
