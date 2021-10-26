using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenu : MonoBehaviour
{
    public GameObject creditsWindow;
    public GameObject credits1;
    public GameObject credits2;
    public int activeCredits = 1;
    public void Close(){
        creditsWindow.SetActive(false);
    }
    public void SwitchCredits()
    {
        if (activeCredits == 1)
        {
            credits1.SetActive(false);
            credits2.SetActive(true);
            activeCredits = 2;
        }
        else if(activeCredits == 2)
        {
            credits1.SetActive(true);
            credits2.SetActive(false);
            activeCredits = 1; 
        }
    }
}
