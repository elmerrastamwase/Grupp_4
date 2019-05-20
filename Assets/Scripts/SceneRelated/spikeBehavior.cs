using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeBehavior : MonoBehaviour
{
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerHit.playerHp -= 1;
            PlayerHP.hasIFrames = true;
            collision.attachedRigidbody.velocity = new Vector3(10, 5, 0);
        }
    }
}
