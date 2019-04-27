using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestTrap : MonoBehaviour
{

    public Transform player;
    private bool x = false;
    public GameObject gun;
    public BoxCollider2D chestFight;
    public GameObject text;
    public GameObject bossMusic;
    public Animator anim;

    private int rot = 0;

    public void OnTriggerStay2D(Collider2D other)
    {
        if (!x)
            text.SetActive(true);
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("lift", true);
            if (other.CompareTag("Player"))
            {
                x = true;
                text.SetActive(false);
                chestFight.enabled = true;
                bossMusic = Instantiate(bossMusic, transform.position, bossMusic.transform.rotation);
            }
        }
    }

    private void Start()
    {
        gun.transform.Rotate(0, 0, -0.5f * 50);
        text.SetActive(false);
        gun.SetActive(false);
        chestFight.enabled = false;
        
        

    }

    protected float v = 0;
    private bool rott = false;

    private void FixedUpdate()
    {
        if (x)
        {
            if (transform.position.y < 4)
                transform.Translate(0, 0.03f, 0);
            else
            {
                anim.SetBool("hover", true);

                if (!gun.active)
                    gun.SetActive(true);


                transform.Translate(v, 0, 0);
                if (player.position.x - transform.position.x > 0)
                    v += 0.01f;
                else
                    v -= 0.01f;
                //v += (player.position.x - transform.position.x)/1000;
                v /= 1.1f;

                if (rott)
                {
                    gun.transform.Rotate(0, 0, 0.5f);
                    rot--;
                    if (rot < 0)
                    {
                        rot = 100;
                        rott = !rott;
                    }
                }
                else
                {
                    gun.transform.Rotate(0, 0, -0.5f);
                    rot--;
                    if (rot < 0)
                    {
                        rot = 100;
                        rott = !rott;
                    }
                }

            }
        }
    }

}
