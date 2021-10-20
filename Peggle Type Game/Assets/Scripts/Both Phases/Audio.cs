using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    [SerializeField] AudioMixerGroup Master;
    [SerializeField] AudioSource audioSource;
    #region SFX Audio Clips
    [SerializeField] AudioClip pegHitSFX;
    [SerializeField] AudioClip wallHitSFX;
    [SerializeField] AudioClip freeBallSFX;
    [SerializeField] AudioClip ballDespawnSFX;
    [SerializeField] AudioClip goldPegHitSFX;
    #endregion
    #region Song Audio Clips
    [SerializeField] AudioClip mainMenuSong;
    #endregion
    void Start()
    {
        audioSource.outputAudioMixerGroup = Master;
        DontDestroyOnLoad(gameObject);
    }
    #region SoundEffects
    public void PlayPachinkoAudio(int selection)
    {
        switch (selection)
        {
            case 1:
                audioSource.PlayOneShot(pegHitSFX, .5f);
                break;
            case 2:
                audioSource.PlayOneShot(wallHitSFX, .5f);
                break;
            case 3:
                audioSource.PlayOneShot(freeBallSFX, .5f);
                break;
            case 4:
                audioSource.PlayOneShot(ballDespawnSFX, .5f);
                break;
            case 5:
                audioSource.PlayOneShot(goldPegHitSFX, .5f);
                break;
        }
    }
    #endregion
    #region  Songs
    public void PlayMainMenuMusic(){
        audioSource.clip = mainMenuSong;
        audioSource.Play();
    }
    #endregion
}