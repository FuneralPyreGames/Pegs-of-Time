using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PachinkoAudio : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip pegHitSFX;
    [SerializeField] AudioClip wallHitSFX;
    [SerializeField] AudioClip freeBallSFX;
    [SerializeField] AudioClip ballDespawnSFX;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayNoise(int selection)
    {
        switch (selection)
        {
            case 1:
                Debug.Log("Playing ball hit soundeffect");
                audioSource.PlayOneShot(pegHitSFX, .5f);
                break;
            case 2:
                Debug.Log("Playing wall hit soundeffect");
                audioSource.PlayOneShot(wallHitSFX, .5f);
                break;
            case 3:
                audioSource.PlayOneShot(freeBallSFX, .5f);
                break;
            case 4:
                audioSource.PlayOneShot(ballDespawnSFX, .5f);
                break;
        }
    }
}
