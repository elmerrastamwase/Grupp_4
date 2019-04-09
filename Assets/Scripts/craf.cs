using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class craf : MonoBehaviour
{

    public float flipTimer = 2;
    float flipTime;
    public Rigidbody2D rBody;
    public Animator anim;
    bool rolling;

    // Start is called before the first frame update
    void Start()
    {
        flipTime = flipTimer;
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rolling == false)
        {
            transform.Translate(1 * Time.deltaTime, 0, 0);
            if (flipTime > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            flipTime -= Time.deltaTime;
            if (flipTime <= -flipTimer)
            {
                flipTime = flipTimer;
            }
        } else
        {
            if (rBody.velocity.x > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (rBody.velocity.x < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }

        if (rBody.velocity.x != 0)
        {
            rolling = true;
            anim.SetBool("Rolling", true);
        }
        else
        {
            rolling = false;
            anim.SetBool("Rolling", false);
        }
    }
}
