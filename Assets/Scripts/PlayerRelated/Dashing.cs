
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : MonoBehaviour
{


    public Rigidbody2D rbody;
    public static float dashSpeed;
    public float dashTimer;
    public float cooldownLeft = 0;
    public static float cooldown = 0.5f;
    public static bool hasAirdash;
    public static bool isDashing;
    public Animator anim;
    public ParticleSystem bubles;
    public GameObject SFX;

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
                        ParticleSystem particle = Instantiate(bubles, transform.position, bubles.transform.rotation);
                        Destroy(particle, bubles.main.duration);
                        SFX = Instantiate(SFX, transform.position, SFX.transform.rotation);
                    }
                } else {
                cooldownLeft = cooldown;
                dashTimer = 0.3f;
                    ParticleSystem particle = Instantiate(bubles, transform.position, bubles.transform.rotation);
                    Destroy(particle, bubles.main.duration);
                    SFX = Instantiate(SFX, transform.position, SFX.transform.rotation);
                }
                
            }
        }

        if (dashTimer > 0)
        {
            rbody.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation; 


            rbody.AddForce(new Vector2(dashSpeed, 0), ForceMode2D.Impulse);
            dashTimer -= Time.deltaTime;
            isDashing = true;
            anim.SetBool("isDashing", true);
        }
        else
        {
            anim.SetBool("isDashing", false);
            dashTimer = 0;
            rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
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