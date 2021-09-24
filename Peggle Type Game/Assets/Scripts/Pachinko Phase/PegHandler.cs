using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegHandler : MonoBehaviour
{
    [SerializeField]Animator pegAnim;
    private PachinkoData pachinkoData;
    // Start is called before the first frame update
    void Start()
    {
        pachinkoData = GameObject.Find("PachinkoData").GetComponent<PachinkoData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        pachinkoData.PlayAudio(1);
        StartCoroutine(Failsafe());
    }
    void OnCollisionExit2D(Collision2D collision){
        StartCoroutine(NewPegDisappear());
    }

    IEnumerator NewPegDisappear(){
        CircleCollider2D cc2D = gameObject.GetComponent<CircleCollider2D>();
        cc2D.enabled = false;
        pegAnim = gameObject.GetComponent<Animator>();
        pegAnim.SetTrigger("Peg Hit");
        yield return new WaitForSeconds(1.417f);
        gameObject.SetActive(false);
    }
    IEnumerator Failsafe()
    {
        yield return new WaitForSeconds(3.5f);
        StartCoroutine(NewPegDisappear());
    }
}
