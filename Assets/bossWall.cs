using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossWall : MonoBehaviour
{
    public static bool bossDoor;
    public GameObject crunch;

    public void Update()
    {
        if (bossDoor == true)
        {
            if (transform.position.y > -2.5f)
            {
                transform.Translate(10 * Time.deltaTime, 0, 0);
            }
            else if (transform.position.y < -2.5f)
            {
                transform.position = new Vector3(transform.position.x, -2.5f);
                crunch = Instantiate(crunch, transform.position, crunch.transform.rotation);
            }
        }
    }

}
