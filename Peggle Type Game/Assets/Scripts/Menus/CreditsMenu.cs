using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenu : MonoBehaviour
{
    public GameObject creditsWindow;
    public void Close(){
        creditsWindow.SetActive(false);
    }
}
