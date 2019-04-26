using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int moveSpeed = 300;
    public float jumpForce = 10;
    public Transform feetPos;
    public float checkRadius = 0.5f;
    public LayerMask whatIsGround;
    public float jumpTime = 0.6f;
    public bool isJumping;
    public static bool isGrounded;
    private float jumpTimeTimer;
    public static int direction = 1;
    public Transform headPos;
    public bool isTouchingRoof;

    [Header("PlayerComponents")]
    public Animator anim;
    private SpriteRenderer sprit;
    private Rigidbody2D rbody;
    private Transform transf;

    // Start is called before the first frame update
    void Start()
    {
        direction = 1;
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        transform.position = Gamemaster.lastCheckPointPos;
        sprit = GetComponent<SpriteRenderer>();
        transf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        animations();

        if (Dashing.isDashing == false)
        {
            float xMovement = Input.GetAxis("Horizontal");

            rbody.AddForce(new Vector2(xMovement * moveSpeed * Time.deltaTime, 0), ForceMode2D.Impulse); //Adds force for movement.


                if (rbody.velocity.x > 0 || rbody.velocity.x < 0)
                {
                    if (rbody.velocity.x < 0)
                    {
                        transf.rotation = Quaternion.Euler(0, 180f, 0);
                        direction = 8;
                        Dashing.dashSpeed = -15;
                    }
                    else if (rbody.velocity.x > 0)
                    {
                        transf.rotation = Quaternion.Euler(0, 0, 0);
                        direction = -8;
                        Dashing.dashSpeed = 15;
                    }

                    if (isGrounded == true)
                    {
                        anim.SetBool("isRunning", true);
                    }
                }

            if (rbody.velocity.x == 0)
            {
                anim.SetBool("isRunning", false);
            }

        }

        Attacking.playerXPos = transform.position.x;

        jumpScript();

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        isTouchingRoof = Physics2D.OverlapCircle(headPos.position, checkRadius, whatIsGround);
    }

    void tables()
    {
        transform.eulerAngles = new Vector3(90, 0, 0);
    }
    /*the tables have turned*/


    public void animations()
    {
        if (rbody.velocity.y < -0.1)
        {
            anim.SetBool("isFalling", true);
            anim.SetBool("isJumpingUp", false);
        }
        if (rbody.velocity.y > 0.1)
        {
            anim.SetBool("isJumpingUp", true);
            anim.SetBool("isFalling", false);
        }

        else if (isGrounded == true)
        {
            anim.SetBool("isJumpingUp", false);
            anim.SetBool("isFalling", false);
        }
    }

    public void jumpScript()
    {

        if (isGrounded == true && Input.GetButton("Jump"))
        {
            isJumping = true;
            jumpTimeTimer = jumpTime;
            GetComponent<Rigidbody2D>().velocity = new Vector2(rbody.velocity.x, jumpForce);
            Dashing.hasAirdash = true;
        }
        if (Input.GetButton("Jump") && isJumping == true)
        {
            if (jumpTimeTimer > 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(rbody.velocity.x, jumpForce);
                jumpTimeTimer -= Time.deltaTime;
            }
        }
        if (Input.GetButtonUp("Jump") || isJumping == false || isTouchingRoof == true)
        {
            isJumping = false;
        }
    }
}