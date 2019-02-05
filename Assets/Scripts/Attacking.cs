using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    void Start()
    {
        trans = GetComponent<Transform>();
    }

    void Update()
    {
        attackCooldown += Time.deltaTime;

        AttackScript();
    }

    public int attackSpeed;
    public Transform trans;

    public float attackCooldown;
    public int attackDamage;


    public int SwingSpeed = 5;

    public void AttackScript()
    {

        if (attackCooldown >= 3)
        {
            Vector2 from = new Vector2(5.5f, 1.5f);
            Vector2 to = new Vector2(-4.5f, -2.5f);

            float angle = Vector2.Angle(from, to);
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.Mouse0))
            {
                trans.localRotation = Quaternion.Lerp(transform.rotation, rotation, SwingSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.Mouse0))
            {
                trans.position = new Vector2(-1, 0);
                attackCooldown = 0f;
            }
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Mouse0))
            {
                trans.position = new Vector2(0, 10);
                attackCooldown = 0f;
            }
            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Mouse0))
            {
                trans.position = new Vector2(0, 0);
                attackCooldown = 0f;
            }
        }
    }
}