using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : MonoBehaviour
{


    private Rigidbody2D rbody;
    public float dashtime;
    public float dashspeed;
    public float startdashtime = 1f;
    public float coldown = 0;
    private int direction;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        dashtime = startdashtime;
        rbody.velocity = Vector2.zero;
    }

     void  Update()
    {

        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && coldown == 0)
            {
                direction = 1;
                coldown = 1;

            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && coldown == 0)
            {
                direction = 2;
                coldown = 1;
            }
            else
            {
                if (dashtime <= 0)
                {
                    direction = 0;
                    dashtime = startdashtime;
                }
            }
        }
        else
        {
            dashtime -= Time.deltaTime;
            if (dashtime <= 0)
            {
                direction = 0;
                dashtime = startdashtime;
            }
            if (direction == 1)
            {
                rbody.velocity = Vector2.left * dashspeed;


            }
            if (direction == 2)
            {
                rbody.velocity = Vector2.right * dashspeed;
            }

        }

        if (coldown >= 0)
        {
            coldown -= Time.deltaTime;
        }
        if (coldown <= 0)
        {
            coldown = 0;
        }
    }
}