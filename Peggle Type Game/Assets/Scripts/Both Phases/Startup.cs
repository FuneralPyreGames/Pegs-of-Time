using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Startup : MonoBehaviour
{
    public GameObject audioPrefab;
    void Start()
    {
        if (GameObject.Find("Audio(Clone)") == null){
            Instantiate(audioPrefab, new Vector3(0, 0, 0), audioPrefab.transform.rotation);
        }
        Destroy(gameObject);
    }
}
