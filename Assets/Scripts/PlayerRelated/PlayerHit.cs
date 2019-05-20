using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public float hitstun;
    public static int playerHp;
    public PlayerMovement playerM;
    public GameObject SFX;
    
    public void Awake()
    {
        playerHp = PlayerHPVariables.maxPlayerHp;

        playerM = GetComponent<PlayerMovement>();
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (PlayerHP.hasIFrames == false)
            {
                SFX = Instantiate(SFX, transform.position, SFX.transform.rotation);
                playerHp -= 1;
                PlayerHP.hasIFrames = true;
                collision.attachedRigidbody.velocity = new Vector3(10, 5, 0);
                hitstun = 0.5f;
            }
        }
    }
}
