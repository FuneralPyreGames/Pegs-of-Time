using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PachinkoData : MonoBehaviour
{
    public int balls = 10;
    public bool isAbleToShoot = true;
    public TextMeshProUGUI ballsText;
    public Animator failAnim;
    public PachinkoAudio pachinkoAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            failAnim.SetTrigger("HasFailed");
        }
    }
    public void PlayAudio(int input)
    {
        pachinkoAudio.PlayNoise(input);
    }
}
