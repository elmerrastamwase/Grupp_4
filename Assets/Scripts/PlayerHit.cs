using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
   
    // Update is called once per frame
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
            }
        }
    }
}
