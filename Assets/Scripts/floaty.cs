﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floaty : MonoBehaviour
{
    float bounceTimer = 0.5f;

    // Update is called once per frame
    void Update()
    {
        bounceTimer -= 1 * Time.deltaTime;
        if (bounceTimer <= 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,2.5f);
            bounceTimer = 1;
        }
    }
}
