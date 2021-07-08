using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;

    public Animator animator;

    public SpriteRenderer spriteRenderer;

    private GameController gameController;

    public float speed;

    public float jumpForce;

    public float hp;

    public bool damage;

    public float damageView;

    bool isJumping;

    float direction;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }


    void Update()
    {
        movePlayer();
    }

    void FixedUpdate() {
        rigidbody2D.velocity = new Vector2(direction * speed, rigidbody2D.velocity.y);
    }

    void movePlayer()
    {
        direction = Input.GetAxisRaw("Horizontal");
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

    public void damageHit()
    {
        if (damage == false)
        {
            gameController.playerLostHp(hp);
            hp--;
            damage = true;
            StartCoroutine(hpPlayer());
        }
    }

    IEnumerator hpPlayer()
    {
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(damageView);
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(damageView);
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(damageView);
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(damageView);
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(damageView);
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(damageView);
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(damageView);
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(damageView);
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(damageView);
        spriteRenderer.enabled = true;
        damage = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isJumping = false;
        }
    }
}
