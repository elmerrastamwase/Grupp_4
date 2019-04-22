using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpMovement : MonoBehaviour
{
    public float flipTimer = 2;
    float flipTime;

    // Start is called before the first frame update
    void Start()
    {
        flipTime = flipTimer;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-2 * Time.deltaTime, 0, 0);
        if (flipTime > 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        flipTime -= Time.deltaTime;
        if (flipTime <= -flipTimer)
        {
            flipTime = flipTimer;
        }
    }
}
