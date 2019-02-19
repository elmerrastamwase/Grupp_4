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
    public int dashcharges = 1;
    
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        dashtime = startdashtime;
        rbody.velocity = Vector2.zero;

    }

    void Update()
    {

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