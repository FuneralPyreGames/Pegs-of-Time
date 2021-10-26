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
    [SerializeField] AudioClip townSong;
    [SerializeField] AudioClip pachinkoLevel1Song;
    [SerializeField] AudioClip pachinkoLevel2Song;
    [SerializeField] AudioClip pachinkoLevel3Song;
    [SerializeField] AudioClip pachinkoLevel4Song;
    [SerializeField] AudioClip pachinkoLevel5Song;
    [SerializeField] AudioClip pachinkoLevel6Song;
    [SerializeField] AudioClip startOfGameSong;
    [SerializeField] AudioClip romanLabSong;
    [SerializeField] AudioClip endOfGameSong;
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
    public void PlayStartOfGameMusic()
    {
        audioSource.clip = startOfGameSong;
        audioSource.Play();
    }
    public void PlayRomanLabMusic()
    {
        audioSource.clip = romanLabSong;
        audioSource.Play();
    }
    public void PlayEndOfGameMusic()
    {
        audioSource.clip = endOfGameSong;
        audioSource.Play();
    }
    public void PlayTownMusic()
    {
        audioSource.clip = townSong;
        audioSource.Play();
    }
    public void PlayPachinkoMusic(int level){
        switch (level)
        {
            case 1:
                audioSource.clip = pachinkoLevel1Song;
                audioSource.Play();
                break;
            case 2:
                audioSource.clip = pachinkoLevel2Song;
                audioSource.Play();
                break;
            case 3:
                audioSource.clip = pachinkoLevel3Song;
                audioSource.Play();
                break;
            case 4:
                audioSource.clip = pachinkoLevel4Song;
                audioSource.Play();
                break;
            case 5:
                audioSource.clip = pachinkoLevel5Song;
                audioSource.Play();
                break;
            case 6:
                audioSource.clip = pachinkoLevel6Song;
                audioSource.Play();
                break;
        }
    }
    #endregion
}