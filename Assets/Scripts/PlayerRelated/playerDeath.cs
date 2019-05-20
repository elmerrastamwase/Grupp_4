using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerDeath : MonoBehaviour
{
    public SpriteRenderer deadPlayer;
    public string sceneToLoad;
    public Image darkness;
    private float dTimer;
    public Animator anim;


    void Start()
    {
        dTimer = 100;
        
        darkness.color = new Color(1, 1, 1, 0);
    }


    void Update()
    {
        if (PlayerHit.playerHp <= 0)
        {
            deadPlayer.enabled = true;
            if (dTimer > 0)
            {
                dTimer--;
                darkness.color = new Color(0, 0, 0, 1 - (dTimer * 0.01f));
            }
            else
            {
                PlayerHit.playerHp = 5;
                dTimer = 75;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
