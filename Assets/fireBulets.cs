using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBulets : MonoBehaviour
{
    public GameObject prefab;

    public int fireSpeed = 20;
    private int fireS;

    private void FixedUpdate()
    {
        fireS--;
        if (fireS < 0)
        {
            fireS = fireSpeed;

            Instantiate(prefab, transform.position, transform.rotation);
        }
    }
}
