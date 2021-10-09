using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PachinkoData : MonoBehaviour
{
    #region Variables
    public int balls = 10;
    public bool isAbleToShoot = true;
    public int goldPegsLeft = 25;
    public TextMeshProUGUI ballsText;
    public TextMeshProUGUI goldPegText;
    public Animator failAnim;
    public Animator winAnim;
    public Audio pachinkoAudio;
    public PegAssigner pegAssigner;
    public SceneChangeManager sceneChangeManager;
    public PersistentData persistentData;
    public int currentLevel;
    #endregion
    void Awake()
    {
        pegAssigner.AssignGoldPegs();
        StartCoroutine(AwakeTime());
    }
    public void CheckPegState(bool goldPeg){
        if (goldPeg == true){
            goldPegsLeft -= 1;
            SetGoldPegCount();
            if (goldPegsLeft == 0){
                Win();
            }
        }
    }
    public void Win(){
        isAbleToShoot = false;
        winAnim.SetTrigger("GameWon");
        sceneChangeManager = GameObject.Find("SceneChangeManager(Clone)").GetComponent<SceneChangeManager>();
        persistentData = GameObject.Find("PersistentData(Clone)").GetComponent<PersistentData>();
        switch (currentLevel)
        {
            case 1:
                sceneChangeManager.LoadStartOfGameReturn();
                break;
            case 2:
                persistentData.pachinkoLevel2Done = true;
                sceneChangeManager.LoadTown("Pachinko Level 2");

                break;
        }
    }
    public void Lose(){
        isAbleToShoot = false;
        failAnim.SetTrigger("HasFailed");
    }
    public void SetGoldPegCount(){
        goldPegText.text = "";
        goldPegText.text += goldPegsLeft;
        goldPegText.text += "/25 Gold Pegs";
    }
    public void SetBallCount()
    {
        ballsText.text = "";
        ballsText.text += balls;
        ballsText.text += " Balls";
    }
    public void SetAbleToShoot()
    {
        if (balls > 0){
            isAbleToShoot = true;
        }
        else if (balls <= 0)
        {
            isAbleToShoot = false;
            Lose();
        }
    }
    public void PlayAudio(int input)
    {
        pachinkoAudio.PlayPachinkoAudio(input);
    }
    IEnumerator AwakeTime(){
        yield return new WaitForSeconds(.25f);
        pachinkoAudio = GameObject.Find("Audio(Clone)").GetComponent<Audio>();
    }
}
