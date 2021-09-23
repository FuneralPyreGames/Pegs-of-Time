using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionExit2D(Collision2D collision){
        StartCoroutine(PegDisappear());
    }

    IEnumerator PegDisappear(){
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(0,0,0,0.5f);
        yield return new WaitForSeconds(0.25f);
        gameObject.SetActive(false);
    }
}
