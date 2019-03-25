using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : MonoBehaviour
{


    private Rigidbody2D rbody;
    public float dashTime;
    public static float dashSpeed;
    public float dashTimer;
    public float cooldownLeft = 0;
    public static float cooldown = 0.5f;
    public static bool hasAirdash;
    public static bool isDashing;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (cooldownLeft == 0)
            {
                if (PlayerMovement.isGrounded == false)
                {
                    if(hasAirdash == true)
                    {
                        cooldownLeft = cooldown;
                        dashTimer = 0.3f;
                        hasAirdash = false;
                    }
                } else {
                cooldownLeft = cooldown;
                dashTimer = 0.3f;
                }
            }
        }

        if (dashTimer > 0)
        {
            rbody.constraints = RigidbodyConstraints2D.FreezePositionY;
            //transform.Translate(dashSpeed * Time.deltaTime, 0, 0);
            rbody.AddForce(new Vector2(dashSpeed, 0), ForceMode2D.Impulse);
            dashTimer -= Time.deltaTime;
            isDashing = true;
        }
        else
        {
            dashTimer = 0;
            rbody.constraints = RigidbodyConstraints2D.None;
            isDashing = false;
        }

        if (cooldownLeft >= 0)
        {
            cooldownLeft -= Time.deltaTime;
        }
        if (cooldownLeft <= 0)
        {
            cooldownLeft = 0;
        }

    }
}