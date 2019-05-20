using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBoss : MonoBehaviour
{

    public Transform player;
    public Vector2 minMax;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Max(Mathf.Min(player.transform.position.x, minMax.y),minMax.x), transform.position.y, transform.position.z);
    }
}
