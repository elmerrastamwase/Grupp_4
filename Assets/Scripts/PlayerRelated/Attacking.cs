using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    public static float attackCooldown;
    public float attackState;
    public static int attackDamage;
    public GameObject player;
    public Rigidbody2D rbody;
    public Animator anim;
    public static float playerXPos;
    public float knockback;
    private float sideKnock;
    public static float isAttacking;
    public GameObject SFX;
    public static bool isLookingUp;
    public static bool isLookingDown;

    void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    void FixedUpdate()
    {

        if (attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
        }
        else { attackCooldown = 0; }

        if (sideKnock > 0)
        {
            rbody.velocity = new Vector2(PlayerMovement.direction, rbody.velocity.y);
            sideKnock -= Time.deltaTime;
        }
        else
        {
            sideKnock = 0;
            rbody.velocity = new Vector2(0, rbody.velocity.y);
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
            Air.air += Random.Range(15, 5);

            collision.attachedRigidbody.velocity = (transform.right * knockback);
            sideKnock = 0.1f;

        }
    }

    public void AttackScript()
    {
        float lookUpOrDown = Input.GetAxis("LookUpOrDown");
        if (lookUpOrDown > 0.6)
            isLookingUp = true;
        else isLookingUp = false;
        if (lookUpOrDown < -0.6)
            isLookingDown = true;
        else isLookingDown = false;

        if (isLookingUp == false)
            if (isLookingDown == false)
                if (attackCooldown <= 0 && Input.GetButtonDown("Fire1"))
                {
                    Attacking.isAttacking = 0.2f;
                    GetComponent<BoxCollider2D>().enabled = true;
                    attackState = 0.2f;
                    attackCooldown = 0.5f;
                    SFX = Instantiate(SFX, transform.position, SFX.transform.rotation);

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

        if (isLookingUp == true)
        {
            anim.SetBool("facingUp", true);
        }
        if (isLookingUp == false)
        {
            anim.SetBool("facingUp", false);
        }
        if (isLookingDown == true)
        {
            anim.SetBool("facingDown", true);
        }
        if (isLookingDown == false)
        {
            anim.SetBool("facingDown", false);
        }

    }
}