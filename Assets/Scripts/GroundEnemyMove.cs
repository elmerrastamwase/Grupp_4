using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemyMove : MonoBehaviour
{
    public bool isRight = true;
    public float movementSpeed = 2f;

    private Rigidbody2D rbody;
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (isRight == true)
        {
            rbody.velocity = new Vector2(-movementSpeed, rbody.velocity.y);
        }
        else
        {
            rbody.velocity = new Vector2(movementSpeed, rbody.velocity.y);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EndOfPlatform")
        {
            if(isRight == true)
            {
                isRight = false;
                transform.Rotate(0, 180, 0);
            }
            else
            {
                isRight = true;
                transform.Rotate(0, 180, 0);
            }
            
        }
    }
}
