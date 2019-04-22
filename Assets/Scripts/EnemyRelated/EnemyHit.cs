using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public int Hp;
    public float flash;
    public SpriteRenderer rend;

    void Start()
    {
        rend = GetComponentInParent<SpriteRenderer>();
    }

    void Update()
    {
        if (Hp == 0)
        {           
            Destroy(transform.parent.gameObject);
        }

        if (flash > 0)
        {
            rend.color = Color.red;
            flash -= Time.deltaTime;
        } else
        {
            rend.color = Color.white;
            flash = 0;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hazard")
        {
            Hp -= 1;
            flash = .1f;
        }
    }
}
