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
        else
        {
            attackCooldown = 0;
        }

        AttackScript();
    }

    public Transform trans;

    public float attackCooldown;
    public int attackDamage;
    public float attackState;
    public GameObject player;
    public Vector3 Offset = new Vector3(0.5f, 0, 0);
    public Animator anim;

    public void AttackScript()
    {       
        if (attackCooldown <= 0 && Input.GetKeyDown(KeyCode.K))
        {
            GetComponent<BoxCollider2D>().enabled = true;
            attackState = 0.2f;
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
            anim.SetBool("isAttacking",false);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(-1.5f, 1.5f, 0);
            anim.SetBool("facingUp", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            transform.Translate(1.5f, -1.5f, 0);
            anim.SetBool("facingUp", false);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(-1.5f, -1.5f, 0);
            anim.SetBool("facingDown", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            transform.Translate(1.5f, 1.5f, 0);
            anim.SetBool("facingUp", false);
        }
    }
}