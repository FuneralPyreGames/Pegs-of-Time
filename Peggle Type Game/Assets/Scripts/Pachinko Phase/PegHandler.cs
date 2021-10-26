using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegHandler : MonoBehaviour
{
    [SerializeField]Animator pegAnim;
    private PachinkoData pachinkoData;
    public bool GoldPeg;
    public int beenHit = 0;
    public Sprite goldPeg;
    void Start()
    {
        pachinkoData = GameObject.Find("PachinkoData").GetComponent<PachinkoData>();
    }
    public void setGoldPeg(){
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        pachinkoData = GameObject.Find("PachinkoData").GetComponent<PachinkoData>();
        goldPeg = pachinkoData.goldPegSprite;
        sr.sprite = goldPeg;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        beenHit += 1;
        if (GoldPeg == false){
            pachinkoData.PlayAudio(1);
        }
        else if (GoldPeg == true){
            pachinkoData.PlayAudio(5);
        }
        StartCoroutine(Failsafe());
    }
    void OnCollisionExit2D(Collision2D collision){
        StartCoroutine(NewPegDisappear());
    }
    void CheckPegState(){
        pachinkoData.CheckPegState(GoldPeg);
    }
    IEnumerator NewPegDisappear(){
        if (beenHit == 1)
        {
        CheckPegState();
        }
        StartCoroutine(TurnOffCollider());
        pegAnim = gameObject.GetComponent<Animator>();
        pegAnim.SetTrigger("Peg Hit");
        yield return new WaitForSeconds(1.417f);
        gameObject.SetActive(false);
    }
    IEnumerator TurnOffCollider()
    {
        yield return new WaitForSeconds(0.15f);
        CircleCollider2D cc2D = gameObject.GetComponent<CircleCollider2D>();
        cc2D.enabled = false;
    }
    IEnumerator Failsafe()
    {
        yield return new WaitForSeconds(3.5f);
        StartCoroutine(NewPegDisappear());
    }
}
