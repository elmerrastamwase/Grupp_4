using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestDamage : MonoBehaviour
{
    public int Hp;
    public float flash;
    private SpriteRenderer rend;
    public ParticleSystem bubles;
    public GameObject SFX;
    public GameObject DeathChest;
    public static Vector2 chestLocation;

    void Start()
    {
        rend = GetComponentInParent<SpriteRenderer>();
    }

    void Update()
    {
        chestLocation = transform.position;
        if (Hp == 0)
        {
            Instantiate(DeathChest);
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
        }
    }
}
