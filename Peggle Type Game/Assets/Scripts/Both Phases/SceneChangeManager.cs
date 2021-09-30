using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void LoadPachinkoLevel(string pachinkoLevel){
        switch (pachinkoLevel){
            case "Pachinko Level 1":
                SceneManager.LoadScene("Pachinko Level 1");
                break;
        }
    }
}
