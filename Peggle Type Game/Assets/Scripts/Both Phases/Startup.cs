using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Startup : MonoBehaviour
{
    public GameObject audioPrefab;
    public GameObject dialogueManagerPrefab;
    public GameObject persistentDataPrefab;
    public GameObject sceneChangeManagerPrefab;
    void Start()
    {
        if (GameObject.Find("Audio(Clone)") == null){
            Instantiate(audioPrefab, new Vector3(0, 0, 0), audioPrefab.transform.rotation);
        }
        if (GameObject.Find("Dialogue Manager(Clone)") == null){
            Instantiate(dialogueManagerPrefab, new Vector3(0, 0, 0), dialogueManagerPrefab.transform.rotation);
        }
        if (GameObject.Find("PersistentData(Clone)") == null){
            Instantiate(persistentDataPrefab, new Vector3(0,0,0), persistentDataPrefab.transform.rotation);
        }
        if (GameObject.Find("SceneChangeManager(Clone)") == null){
            Instantiate(sceneChangeManagerPrefab, new Vector3(0,0,0), sceneChangeManagerPrefab.transform.rotation);
        }
        Destroy(gameObject);
    }
}
