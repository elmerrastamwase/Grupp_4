using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int moveSpeed = 5;
    public float jumpForce = 6;
    public Transform feetPos;
    public float checkRadius = 0.5f;
    public LayerMask whatIsGround;
    public float jumpTime = 0.6f;
    public bool isJumping;

    private bool isGrounded;
    private Rigidbody2D rbody;
    private float jumpTimeTimer;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        jumpScript();

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
    }

    public void jumpScript()
    {
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeTimer = jumpTime;
            GetComponent<Rigidbody2D>().velocity = new Vector2(rbody.velocity.x, jumpForce);
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
