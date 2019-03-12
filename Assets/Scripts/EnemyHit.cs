using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public int Hp;

    void Start()
    {
        
    }

    void Update()
    {
        if (Hp == 0)
        {
            
            Destroy(transform.parent.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hazard")
        {
            Hp -= 1;
        }
    }
}
