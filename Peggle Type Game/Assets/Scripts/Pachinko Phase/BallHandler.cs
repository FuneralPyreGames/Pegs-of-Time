using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHandler : MonoBehaviour
{
    [SerializeField]float maxSpeed = 3;
    [SerializeField]Rigidbody2D ballRb;
    public PachinkoData pachinkoData;
    // Start is called before the first frame update
    void Awake()
    {
        pachinkoData = GameObject.Find("PachinkoData").GetComponent<PachinkoData>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ballRb.velocity.magnitude > maxSpeed){
            ballRb.velocity = Vector3.ClampMagnitude(ballRb.velocity, maxSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.name == "BallCollider"){
            pachinkoData.isAbleToShoot = true;
            Destroy(gameObject);
        }
        if (collision.name == "FreeBallBucket Collider"){
            pachinkoData.balls += 1;
            pachinkoData.SetAbleToShoot();
            pachinkoData.SetBallCount();
            Destroy(gameObject);
        }
    }

}
