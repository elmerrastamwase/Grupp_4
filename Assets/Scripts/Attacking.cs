using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    void Update()
    {
        if (attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
        }
        else { attackCooldown = 0; }
        if (upKnock > 0)
        {
            rbody.velocity = new Vector2(rbody.velocity.x, 5);
            upKnock -= Time.deltaTime;
        }
        else { upKnock = 0; }

        if (sideKnock > 0)
        {
            rbody.velocity = new Vector2(PlayerMovement.direction ,rbody.velocity.y);
            sideKnock -= Time.deltaTime;
        } else
        {
            sideKnock = 0;
            rbody.velocity = new Vector2(0, rbody.velocity.y);
        }



        AttackScript();
    }

    public float attackCooldown;
    public int attackDamage;
    public float attackState;
    public GameObject player;
    public Rigidbody2D rbody;
    public Vector3 Offset = new Vector3(0.5f, 0, 0);
    public Animator anim;
    public static float playerXPos;
    public float knockback;
    public float upKnock;
    public float sideKnock;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("enemy hit");
            Air.air += Random.Range(20,10);
            if (Input.GetKey(KeyCode.W))
            {
                collision.attachedRigidbody.velocity = (transform.up * knockback);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                collision.attachedRigidbody.velocity = (transform.up * -knockback * 0.5f);
                upKnock = 0.1f;
                Dashing.hasAirdash = true;
            }
            else
            {
                collision.attachedRigidbody.velocity = (transform.right * knockback);
                sideKnock = 0.1f;
            }
        }
    }

    public void AttackScript()
    {
        if (attackCooldown <= 0 && Input.GetKeyDown(KeyCode.K))
        {
            GetComponent<BoxCollider2D>().enabled = true;
            attackState = 0.2f;
            attackCooldown = 0.6f;
        }
        if (attackState > 0)
        {
            attackState -= Time.deltaTime;
            anim.SetBool("isAttacking", true);
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = false;
            attackState = 0;
            anim.SetBool("isAttacking", false);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(-1f, 1.5f, 0);
            anim.SetBool("facingUp", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            transform.Translate(1f, -1.5f, 0);
            anim.SetBool("facingUp", false);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(-1f, -1.5f, 0);
            anim.SetBool("facingDown", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            transform.Translate(1f, 1.5f, 0);
            anim.SetBool("facingDown", false);
        }
    }
}