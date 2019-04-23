using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public float hitstun;
    public PlayerMovement playerM;


    public void Awake()
    {
        playerM = GetComponent<PlayerMovement>();
    }

    void Update()
    {

    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (PlayerHP.hasIFrames == false)
            {
                Debug.Log("hit");
                PlayerHP.playerHp -= 1;
                PlayerHP.hasIFrames = true;
                collision.attachedRigidbody.velocity = new Vector3(10, 5, 0);
                hitstun = 0.5f;
            }
        }
    }
}
