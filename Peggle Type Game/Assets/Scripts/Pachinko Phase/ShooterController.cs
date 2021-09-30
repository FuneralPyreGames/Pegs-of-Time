using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    public GameObject Guide;
    public GameObject ballPrefab;
    public Transform firePoint;
    public float Speed = 100f;
    public float ballForce = 100f;
    private Vector3 movement;
    public PachinkoData pachinkoData;
    private void Awake()
    {
        pachinkoData = GameObject.Find("PachinkoData").GetComponent<PachinkoData>();
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown("space"))
        {
            if (pachinkoData.isAbleToShoot == true){
                ShootBall();
            }
        }
        if (gameObject.transform.position.x < -0.334)
        {
            gameObject.transform.position = new Vector3 (-0.3339156f, 4.8f);
            Quaternion needQuat = Quaternion.Euler (0, 0, 114);
            gameObject.transform.rotation = needQuat;
        }
        else if (gameObject.transform.position.x > 0.3431475f)
        {
            gameObject.transform.position = new Vector3(0.3431475f, 4.8f);
            Quaternion needQuat = Quaternion.Euler(0, 0, 244);
            gameObject.transform.rotation = needQuat;
        }
    }
    private void FixedUpdate()
    {
        transform.RotateAround(Guide.transform.position, Vector3.forward, movement.x * Speed * Time.deltaTime);
    }
    private void ShootBall()
    {
        pachinkoData.isAbleToShoot = false;
        pachinkoData.balls -= 1;
        pachinkoData.SetBallCount();
        GameObject ball = Instantiate(ballPrefab, gameObject.transform.position, gameObject.transform.rotation);
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * ballForce, ForceMode2D.Impulse);
    }
}
