using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healPlayer : MonoBehaviour
{
    public GameObject SFX;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHit.playerHp += 1;
        SFX = Instantiate(SFX, transform.position, SFX.transform.rotation);

    }
}
