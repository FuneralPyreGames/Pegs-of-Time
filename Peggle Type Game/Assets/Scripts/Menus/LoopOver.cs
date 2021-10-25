using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopOver : MonoBehaviour
{
    public SceneChangeManager sceneChangeManager;
    public void ResetLoop()
    {
        sceneChangeManager = GameObject.Find("SceneChangeManager(Clone)").GetComponent<SceneChangeManager>();
        sceneChangeManager.LoadTownBasic();
    }
    public void MainMenu()
    {
        sceneChangeManager = GameObject.Find("SceneChangeManager(Clone)").GetComponent<SceneChangeManager>();
        sceneChangeManager.LoadMainMenu();
    }
}
