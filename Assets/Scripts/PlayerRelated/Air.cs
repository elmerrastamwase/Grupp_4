using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Air : MonoBehaviour
{
    private Transform bar;
    public static int air;
    public GameObject SFX;
    public Image flash;
    public int timer;
    public Image darkness;
    private int dTimer;
    private int oldHp;
    public SpriteRenderer playerRend;

    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("bar");
        flash.enabled = false;

        darkness.color = new Color(1, 1, 1, 0 );
        oldHp = PlayerHit.playerHp;
    }

    public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(air / 100, 1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerHit.playerHp < oldHp)
        {
            dTimer = 75;

        }
          oldHp = PlayerHit.playerHp; 

        bar.localScale = new Vector3(0.5f, air / 100f);
        if (air >= 100)
        {
            flash.enabled = true;
            timer = 100;
            air = 0;
            PlayerHit.playerHp += 1;
            SFX = Instantiate(SFX, transform.position, SFX.transform.rotation);
        }
        if (timer > 0)
        {
            timer -= 1 ;
            flash.color = new Color(1,1,1,timer *   0.01f);
        }
        else
        {
            flash.enabled = false;
            timer = 0;
        }
        if (dTimer > 0)
        {
            
            dTimer--;
            darkness.color = new Color(1, 1, 1, dTimer * 0.01333333333f);
            if (dTimer -50 > -1)
            {
                playerRend.color = new Color(1, 1- (dTimer - 50) * 0.01333333333f, 1- (dTimer - 50) * 0.01333333333f, 1);
            }
            
        }

  
    }
}
