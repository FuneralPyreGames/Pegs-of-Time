using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    public PersistentData persistentData;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        persistentData = GameObject.Find("PersistentData(Clone)").GetComponent<PersistentData>();
    }
    #region Loaders
    public void StartGame()
    {
        persistentData.Reset();
        SceneManager.LoadScene("StartOfGame");
    }
    public void LoadPachinkoLevel(string pachinkoLevel){
        switch (pachinkoLevel){
            case "Pachinko Level 1":
                SceneManager.LoadScene("Pachinko Level 1");
                break;
            case "Pachinko Level 2":
                SceneManager.LoadScene("Pachinko Level 2");
                break;
            case "Pachinko Level 3":
                SceneManager.LoadScene("Pachinko Level 3");
                break;
            case "Pachinko Level 4":
                SceneManager.LoadScene("Pachinko Level 4");
                break;
            case "Pachinko Level 5":
                SceneManager.LoadScene("Pachinko Level 5");
                break;
            case "Roman's Lab":
                SceneManager.LoadScene("Roman's Lab");
                break;
            case "Pachinko Level 6":
                SceneManager.LoadScene("Pachinko Level 6");
                break;
        }
    }
    public void LoadStartOfGameReturn()
    {
        SceneManager.LoadScene("StartOfGame");
        persistentData.PickLoadSpot("Pachinko Level 1");
    }
    public void LoadTown(string loadspot)
    {
        SceneManager.LoadScene("Town");
        persistentData.PickLoadSpot(loadspot);
    }
    public void LoadTownBasic(){
        SceneManager.LoadScene("Town");
    }
    public void LoadMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadLoopOver()
    {
        SceneManager.LoadScene("LoopOver");
    }
    public void LoadEndOfGame()
    {
        SceneManager.LoadScene("EndOfGame");
    }
    public void LoadTheEnd()
    {
        SceneManager.LoadScene("The End");
    }
    #endregion
}
