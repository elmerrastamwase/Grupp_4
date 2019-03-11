using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floaty : MonoBehaviour
{
    float bounceTimer = 0.5f;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        bounceTimer -= 1 * Time.deltaTime;
        if (bounceTimer <= 0)
        {
            GetComponent<Rigidbody2D>().velocity = (Vector3.up * 0.5f) * 5;
            bounceTimer = 1;
        }
    }
}
