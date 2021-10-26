using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenu : MonoBehaviour
{
    public GameObject optionsWindow;
    public GameObject creditsWindow;
    public SceneChangeManager sceneChangeManager;
    public Audio Audio;
    public GameObject debugTrigger;
    private void Awake() {
        StartCoroutine(DelayedMainMenuMusic());
    }
    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            debugTrigger.SetActive(true);
        }
    }
    public void OpenOptions()
    {
        optionsWindow.SetActive(true);
    }
    public void OpenCredits(){
        creditsWindow.SetActive(true);
    }
    public void Quit(){
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
    public void StartGame(){
        sceneChangeManager = GameObject.Find("SceneChangeManager(Clone)").GetComponent<SceneChangeManager>();
        sceneChangeManager.StartGame();
    }
    public void LoadGame(){
        sceneChangeManager = GameObject.Find("SceneChangeManager(Clone)").GetComponent<SceneChangeManager>();
        sceneChangeManager.LoadTownBasic();
    }
    IEnumerator DelayedMainMenuMusic(){
        yield return new WaitForSeconds(.10f);
        Audio = GameObject.Find("Audio(Clone)").GetComponent<Audio>();
        Audio.PlayMainMenuMusic();
    }
}