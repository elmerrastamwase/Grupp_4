using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagePlayer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHP.playerHp -= 1;
    }
}
