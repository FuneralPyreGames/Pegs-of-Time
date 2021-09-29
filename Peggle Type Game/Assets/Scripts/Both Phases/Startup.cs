using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Startup : MonoBehaviour
{
    public GameObject audioPrefab;
    public GameObject dialogueManagerPrefab;
    void Start()
    {
        if (GameObject.Find("Audio(Clone)") == null){
            Instantiate(audioPrefab, new Vector3(0, 0, 0), audioPrefab.transform.rotation);
        }
        if (GameObject.Find("Dialogue Manager(Clone)") == null){
            Instantiate(dialogueManagerPrefab, new Vector3(0, 0, 0), dialogueManagerPrefab.transform.rotation);
        }
        Destroy(gameObject);
    }
}
