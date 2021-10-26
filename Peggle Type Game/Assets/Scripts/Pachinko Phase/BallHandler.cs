using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHandler : MonoBehaviour
{
    [SerializeField]float maxSpeed = 3;
    [SerializeField]Rigidbody2D ballRb;
    public PachinkoData pachinkoData;
    int numberOfHits = 0;
    // Start is called before the first frame update
    void Awake()
    {
        pachinkoData = GameObject.Find("PachinkoData").GetComponent<PachinkoData>();
        StartCoroutine(Failsafe());
    }
    // Update is called once per frame
    void Update()
    {
        if(ballRb.velocity.magnitude > maxSpeed){
            ballRb.velocity = Vector3.ClampMagnitude(ballRb.velocity, maxSpeed);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        numberOfHits += 1;
        if (collision.gameObject.name == "Left Wall")
        {
            pachinkoData.PlayAudio(2);
        }
        if (collision.gameObject.name == "Right Wall")
        {
            pachinkoData.PlayAudio(2);
        }
        if (collision.gameObject.name == "Top Wall")
        {
            pachinkoData.PlayAudio(2);
        }
    }
    void OnTriggerEnter2D(Collider2D collision){
        if (collision.name == "BallCollider"){
            if(numberOfHits > 0){
                pachinkoData.PlayAudio(4);
                pachinkoData.SetAbleToShoot();
                Destroy(gameObject);
            }
            else if (numberOfHits == 0)
            {
                pachinkoData.balls += 1;
                pachinkoData.SetBallCount();
                pachinkoData.SetAbleToShoot();
            }
        }
        if (collision.name == "FreeBallBucket Collider"){
            pachinkoData.PlayAudio(3);
            pachinkoData.balls += 1;
            pachinkoData.SetAbleToShoot();
            pachinkoData.SetBallCount();
            Destroy(gameObject);
        }
    }
    IEnumerator Failsafe(){
        yield return new WaitForSeconds(15f);
    }
}
