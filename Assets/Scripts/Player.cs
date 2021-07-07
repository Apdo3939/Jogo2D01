using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public Animator animator;
    public float speed;
    public float jumpForce;
    bool isJumping;


    void Start()
    {

    }


    void Update()
    {
        movePlayer();
    }

    void movePlayer()
    {
        float direction = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2(direction * speed, rigidbody2D.velocity.y);
        
        if (direction > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        
        if (direction < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
        
        if (direction != 0 && isJumping == false) 
        {
            animator.SetInteger("controller", 1);
        }
        
        if (direction == 0 && isJumping == false)
        {
            animator.SetInteger("controller", 0);
        }

        jump();
    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetInteger("controller", 2);
            isJumping = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isJumping = false;
        }
    }
}
