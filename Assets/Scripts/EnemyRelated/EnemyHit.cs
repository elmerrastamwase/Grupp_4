using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public int Hp;
    public float flash;
    public SpriteRenderer rend;


    public ParticleSystem bubles;

    public GameObject SFX;
    public GameObject DeathSFX;

    void Start()
    {

        rend = GetComponentInParent<SpriteRenderer>();
    }

    void Update()
    {
        if (Hp <= 0)
        {
            Debug.Log("yeet");
            Destroy(transform.parent.gameObject);
            Destroy(gameObject);
        }

        if (flash > 0)
        {
            rend.color = Color.red;
            flash -= Time.deltaTime;
            if (bubles.isPlaying == false)
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
            SFX = Instantiate(SFX, transform.position, SFX.transform.rotation);
            if (Hp <= 1)
            {
                DeathSFX = Instantiate(DeathSFX, transform.position, DeathSFX.transform.rotation);
            }

        }
    }
}
