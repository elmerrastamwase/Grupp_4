using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    void Start()
    {
        trans = GetComponent<Transform>();

        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        attackCooldown += Time.deltaTime;

        AttackScript();

        WeaponToPlayer();
    }

    private Transform trans;

    public float attackCooldown;
    public int attackDamage;

    public GameObject player;

    public void AttackScript()
    {
        if (attackCooldown >= 0.5f)
        {
            if (Input.GetKey(KeyCode.D))
            {
                trans.rotation = Quaternion.Euler(0, 0, 0);

                if (Input.GetKey(KeyCode.Mouse0))
                {
                    trans.eulerAngles = new Vector3(0, 0, 0);
                    attackCooldown = 0;
                }
            }
            if (Input.GetKey(KeyCode.A))
            {
                trans.rotation = Quaternion.Euler(0, 180, 0);

                if (Input.GetKey(KeyCode.Mouse0))
                {
                    attackCooldown = 0;
                }
            }
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Mouse0))
            {
                attackCooldown = 0;
                trans.eulerAngles = new Vector3(0, 0, 90);
            }
            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Mouse0))
            {
                trans.eulerAngles = new Vector3(0, 0, -90);
                attackCooldown = 0;
            }
        }
    }

    public void WeaponToPlayer()
    {
        if (Input.GetKey(KeyCode.A))
        {
            trans.position = player.transform.position + Offset0;
        }
        else
        {
            trans.position = player.transform.position + Offset0;
        }
    }
    private Vector3 Offset0 = new Vector3(0.5f, 0, 0);
}

