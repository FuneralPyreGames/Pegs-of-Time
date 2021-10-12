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
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void StartLoop()
    {
        StartCoroutine(LoopTimer());
        persistentData = GameObject.Find("PersistentData(Clone").GetComponent<PersistentData>();
        persistentData.loopOn = true;
    }
    public void LoopTimerUp()
    {
        StopAllCoroutines();
        Debug.Log("Loop is over");
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
        secondsText.text = "";
        secondsText.text += seconds;
    }
    IEnumerator LoopTimer()
    {
        Debug.Log("In loop");
        yield return new WaitForSecondsRealtime(1);
        StartCoroutine(LoopTimer());
        if (seconds ==  0){
            minutes -= 1;
            if (minutes == 0){
                LoopTimerUp();
            }
            seconds = 59;
        }
        else{
            seconds -= 1;
        }
        DisplayLoopText();
    }
}
