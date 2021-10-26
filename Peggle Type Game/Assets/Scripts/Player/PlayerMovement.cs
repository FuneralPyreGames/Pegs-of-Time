using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerCollisionController playerCollisionController;
    [SerializeField] float speed = 5f;
    [SerializeField] Rigidbody2D rB;
    [SerializeField] Vector2 movement;
    public bool playerAbleToMove = true;
    public Animator playerAnim;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        playerAnim.SetFloat("Horizontal", movement.x);
        playerAnim.SetFloat("Vertical", movement.y);
        playerAnim.SetFloat("Magnitude", movement.magnitude);
        if (playerAbleToMove == true)
        {
            rB.MovePosition(rB.position + movement * speed * Time.fixedDeltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerCollisionController.DetermineTriggerAction(collision);
    }
}
