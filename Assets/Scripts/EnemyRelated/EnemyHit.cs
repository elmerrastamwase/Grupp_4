using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public int Hp;
    public float flash;
    public SpriteRenderer rend;


    public ParticleSystem bubles;
    public float timer;
    public GameObject SFX;
    public GameObject DeathSFX;

    void Start()
    {

        rend = GetComponentInParent<SpriteRenderer>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (Hp <= 0)
        {
            Destroy(transform.parent.gameObject);
            Destroy(gameObject);
        }

        if (flash > 0)
        {
            rend.color = Color.red;
            flash -= Time.deltaTime;

            
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
            SFX = Instantiate(SFX, transform.position, SFX.transform.rotation);
            ParticleSystem particle = Instantiate(bubles, transform.position, bubles.transform.rotation);
            Destroy(particle, bubles.main.duration);
            if (Hp <= 1)
            {
                DeathSFX = Instantiate(DeathSFX, transform.position, DeathSFX.transform.rotation);
            }

        }
    }
}
