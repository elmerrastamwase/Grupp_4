using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingDown : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rbody;
    public Vector3 Offset = new Vector3(0.5f, 0, 0);
    public Animator anim;
    public static float playerXPos;
    public float knockback;
    private float upKnock;
    public float attackCooldown;
    public float attackState;
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
        if (upKnock > 0)
        {
            rbody.velocity = new Vector2(rbody.velocity.x, 5);
            upKnock -= Time.deltaTime;
        }
        AttackScript();
    }



    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("enemy hit");
            Air.air += Random.Range(20, 10);

            collision.attachedRigidbody.velocity = (transform.up * -knockback * 0.5f);
            upKnock = 0.1f;
            Dashing.hasAirdash = true;

        }
    }

    public void AttackScript()
    {
        if (attackCooldown <= 0 && Input.GetKeyDown(KeyCode.K) && Input.GetKey(KeyCode.S))
        {
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
    }
}
