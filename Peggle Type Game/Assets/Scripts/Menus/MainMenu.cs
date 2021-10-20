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
    private void Awake() {
        StartCoroutine(DelayedMainMenuMusic());
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
    IEnumerator DelayedMainMenuMusic(){
        yield return new WaitForSeconds(.10f);
        Audio = GameObject.Find("Audio(Clone)").GetComponent<Audio>();
        Audio.PlayMainMenuMusic();
    }
}