using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RomanLabAudio : MonoBehaviour
{
    public Audio Audio;
    void Awake()
    {
        Audio = GameObject.Find("Audio(Clone)").GetComponent<Audio>();
        Audio.PlayRomanLabMusic();
    }
}
