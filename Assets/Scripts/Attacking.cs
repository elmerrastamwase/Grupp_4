﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();

        trans = GetComponent<Transform>();
    }

    void Update()
    {
        attackCooldown += Time.deltaTime;

        AttackScript();
    }

    public Rigidbody2D rBody;
    public int attackSpeed;
    public Transform trans;

    public float attackCooldown;
    public int attackDamage;


    public void AttackScript()
    {
        if (attackCooldown >= 3)
        {
            if (Input.GetKeyDown(KeyCode.D) && Input.GetKey(KeyCode.Mouse0))
            {
                trans.position = new Vector2(1,10);
            }
            if (Input.GetKeyDown(KeyCode.A) && Input.GetKey(KeyCode.Mouse0))
            {

            }
            if (Input.GetKeyDown(KeyCode.W) && Input.GetKey(KeyCode.Mouse0))
            {

            }
            if (Input.GetKeyDown(KeyCode.S) && Input.GetKey(KeyCode.Mouse0))
            {

            }
        }
    }
}