using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public int Hp;
    public float flash;
    public SpriteRenderer rend;
    public ParticleSystem Enemyhit;
    public float deathTimer = 0.5f;
    public ParticleSystem bubles;

    void Start()
    {
        deathTimer = .5f;
        rend = GetComponentInParent<SpriteRenderer>();
    }

    void Update()
    {
        if (Hp == 0)
        {
            deathTimer -= Time.deltaTime;
                Destroy(transform.parent.gameObject);
        }

        if (flash > 0)
        {
            rend.color = Color.red;
            flash -= Time.deltaTime;
            if (Enemyhit.isPlaying == false)
            {
               ParticleSystem particle = Instantiate(bubles, transform.position, bubles.transform.rotation);
                Destroy(particle, bubles.main.duration);
            }
        }
        else
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
