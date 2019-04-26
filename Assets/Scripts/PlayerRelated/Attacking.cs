using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    public float attackCooldown;
    public float attackState;
    public static int attackDamage;
    public GameObject player;
    public Rigidbody2D rbody;
    public Animator anim;
    public static float playerXPos;
    public float knockback;
    private float upKnock;
    private float sideKnock;
    public float isAttacking;
    public GameObject SFX;

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

        if (sideKnock > 0)
        {
            rbody.velocity = new Vector2(PlayerMovement.direction ,rbody.velocity.y);
            sideKnock -= Time.deltaTime;
        } else
        {
            sideKnock = 0;
            rbody.velocity = new Vector2(0, rbody.velocity.y);
        }

        if (attackCooldown == 0)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                isAttacking = 0.5f;
            }
        }
        if (isAttacking > 0)
        {
            anim.SetBool("isAttacking", true);
            isAttacking -= Time.deltaTime;
        }
        else
        {
            anim.SetBool("isAttacking", false);
            isAttacking = 0;
        }


        AttackScript();
    }

   

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("enemy hit");
            Air.air += Random.Range(20,10);
             
                collision.attachedRigidbody.velocity = (transform.right * knockback);
                sideKnock = 0.1f;
            
        }
    }

    public void AttackScript()
    {
        if (attackCooldown <= 0 && Input.GetKeyDown(KeyCode.K))
        {
            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
                GetComponent<BoxCollider2D>().enabled = true;
                attackState = 0.2f;
                attackCooldown = 0.5f;
                SFX = Instantiate(SFX, transform.position, SFX.transform.rotation);
            }
        }
        if (attackState > 0)
        {
            attackState -= Time.deltaTime;
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = false;
            attackState = 0;
            GetComponent<SpriteRenderer>().enabled = false;
        }

       if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("facingUp", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("facingUp", false); 
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("facingDown", true);   
        }
        if (Input.GetKeyUp(KeyCode.S))
        {                   
            anim.SetBool("facingDown", false); 
        }

    }
}