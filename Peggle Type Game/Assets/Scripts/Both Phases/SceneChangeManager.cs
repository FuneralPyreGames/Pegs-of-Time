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
    public void StartGame()
    {
        SceneManager.LoadScene("StartOfGame");
    }
    public void LoadPachinkoLevel(string pachinkoLevel){
        switch (pachinkoLevel){
            case "Pachinko Level 1":
                SceneManager.LoadScene("Pachinko Level 1");
                break;
        }
    }
    public void LoadStartOfGameReturn()
    {
        SceneManager.LoadScene("StartOfGame");
        persistentData.PickLoadSpot("Pachinko Level 1");
    }
}
