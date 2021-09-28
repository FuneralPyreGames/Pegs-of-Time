using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PachinkoData : MonoBehaviour
{
    public int balls = 10;
    public bool isAbleToShoot = true;
    public int goldPegsLeft = 25;
    public TextMeshProUGUI ballsText;
    public TextMeshProUGUI goldPegText;
    public Animator failAnim;
    public Animator winAnim;
    public Audio pachinkoAudio;
    public PegAssigner pegAssigner;
    void Start()
    {
        pegAssigner.AssignGoldPegs();
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
}
