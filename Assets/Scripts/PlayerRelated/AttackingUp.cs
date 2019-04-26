﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingUp : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rbody;
    public Vector3 Offset = new Vector3(0.5f, 0, 0);
    public Animator anim;
    public float knockback;
    public float attackCooldown;
    public float attackState;
    public GameObject SFX;

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

        AttackScript();
    }

  

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("enemy hit");
            Air.air += Random.Range(20, 10);
        
                collision.attachedRigidbody.velocity = (transform.up * knockback);
       
        }
    }

    public void AttackScript()
    {
        float lookUpOrDown = Input.GetAxis("LookUpOrDown");

        if (attackCooldown <= 0 && Input.GetButtonDown("Fire1") && lookUpOrDown > 0)
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
