using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoopManager : MonoBehaviour
{
    public int seconds = 0;
    public int minutes = 5;
    public TextMeshProUGUI minutesText;
    public TextMeshProUGUI secondsText;
    public PersistentData persistentData;
    public GameObject loopDisplay;
    public SceneChangeManager sceneChangeManager;
    public Audio Audio; 
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void StartLoop()
    {
        loopDisplay.SetActive(true);
        seconds = 00;
        minutes = 5;
        StartCoroutine(LoopTimer());
        persistentData = GameObject.Find("PersistentData(Clone)").GetComponent<PersistentData>();
        persistentData.loopOn = true;
    }
    public void LoopTimerUp()
    {
        persistentData.loopOn = false;
        StopAllCoroutines();
        loopDisplay.SetActive(false);
        persistentData.Save();
        sceneChangeManager = GameObject.Find("SceneChangeManager(Clone)").GetComponent<SceneChangeManager>();
        Audio = GameObject.Find("Audio(Clone)").GetComponent<Audio>();
        Audio.PlayMainMenuMusic();
        sceneChangeManager.LoadLoopOver();
    }
    public void StopLoop()
    {
        persistentData.loopOn = false;
        StopCoroutine(LoopTimer());
        loopDisplay.SetActive(false);
    }
    public void DisplayLoopText()
    {
        if (seconds == 1){
            seconds = 01;
        }
        else if (seconds == 2){
            seconds = 02;
        }
        else if (seconds == 3){
            seconds = 03;
        }
        else if (seconds == 4){
            seconds = 04;
        }
        else if (seconds == 5){
            seconds = 05;
        }
        else if (seconds == 6){
            seconds = 06;
        }
        else if (seconds == 7){
            seconds = 07;
        }
        else if (seconds == 8){
            seconds = 08;
        }
        else if (seconds == 9){
            seconds = 09;
        }
        minutesText.text = "";
        minutesText.text += minutes;
        secondsText.text = string.Format("{00}", seconds);
        //secondsText.text = "";
        //secondsText.text += seconds;
    }
    IEnumerator LoopTimer()
    {
        yield return new WaitForSecondsRealtime(1);
        StartCoroutine(LoopTimer());
        if (seconds ==  0){
            if (minutes == 0){
                LoopTimerUp();
            }
            minutes -= 1;
            seconds = 59;
        }
        else{
            seconds -= 1;
        }
        DisplayLoopText();
    }
}
