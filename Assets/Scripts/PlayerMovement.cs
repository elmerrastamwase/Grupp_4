﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int moveSpeed = 50;
    public float jumpForce = 10;
    public Transform feetPos;
    public float checkRadius = 0.5f;
    public LayerMask whatIsGround;
    public float jumpTime = 0.6f;
    public bool isJumping;
    public static bool isGrounded;
    private Rigidbody2D rbody;
    private float jumpTimeTimer;
    public static int direction;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().freezeRotation = true;

        animations();
        if (Dashing.isDashing == false)
        {
            if (Input.GetKey(KeyCode.D))
            {
                rbody.AddForce(new Vector2(moveSpeed * Time.deltaTime, 0), ForceMode2D.Impulse);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                direction = -8;
            }
            if (Input.GetKey(KeyCode.A))
            {
                rbody.AddForce(new Vector2(-moveSpeed * Time.deltaTime, 0), ForceMode2D.Impulse);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                direction = 8;
            }
           
        }

        Attacking.playerXPos = transform.position.x;

        jumpScript();

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
    }

    public void animations()
    {
        if (rbody.velocity.y < -0.1)
        {
            anim.SetBool("isFalling", true);
        } else {
            anim.SetBool("isFalling", false);
        }
        if (rbody.velocity.y > -0.1)
        {
            anim.SetBool("isJumpingUp", true);
        }
        else
        {
            anim.SetBool("isJumpingUp", false);
        }
        if(isGrounded == true)
        {
            anim.SetBool("isJumpingUp", false);
            anim.SetBool("isFalling", false);
        }
    }

    public void jumpScript()
    {
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeTimer = jumpTime;
            GetComponent<Rigidbody2D>().velocity = new Vector2(rbody.velocity.x, jumpForce);
            Dashing.hasAirdash = true;
        }
        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeTimer > 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(rbody.velocity.x, jumpForce);
                jumpTimeTimer -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }
}
