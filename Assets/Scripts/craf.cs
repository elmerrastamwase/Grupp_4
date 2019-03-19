using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class craf : MonoBehaviour
{

    public float flipTimer = 2;
    float flipTime;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        flipTime = flipTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (flipTime > 0)
        {
            transform.Translate(1 * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.Translate(-1 * Time.deltaTime, 0, 0);
        }

        flipTime -= Time.deltaTime;
        if (flipTime <= -flipTimer)
        {
            flipTime = flipTimer;
        }
    }
}
