using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestDeath : MonoBehaviour
{
    public int Hp;
    public float flash;
    public SpriteRenderer rend;
    public ParticleSystem bubles;
    public GameObject SFX;
    public GameObject DeathChest;

    void Start()
    {

        rend = GetComponentInParent<SpriteRenderer>();
    }

    void Update()
    {
        if (Hp == 0)
        {
            Instantiate(DeathChest);
           
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
