using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public static bool hasIFrames;
    public float iFrames = 2;
    private Gamemaster gm;
    public Image[] tanks;
    public Sprite fullTank;
    public Sprite emptyTank;
    public SpriteRenderer player;
    public GameObject deadPlayer;
    //public static int sceneHP;



    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string currentSceneName = currentScene.name;

        if (currentSceneName == "Tutorial")
        {
            PlayerHit.playerHp = PlayerHPVariables.maxPlayerHp;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerHit.playerHp > PlayerHPVariables.maxPlayerHp)
        {
            PlayerHit.playerHp = PlayerHPVariables.maxPlayerHp;
        }

        if (hasIFrames == true)
        {
            iFrames -= 1 * Time.deltaTime;
            if (iFrames <= 0)
            {
                hasIFrames = false;
                iFrames = 2;
            }
        }
        for (int i = 0; i < tanks.Length; i++)
        {
            if (i < PlayerHit.playerHp)
            {
                tanks[i].sprite = fullTank;
            }
            else
            {
                tanks[i].sprite = emptyTank;
            }

            if (i < PlayerHPVariables.maxPlayerHp)
            {
                tanks[i].enabled = true;
            }
            else
            {
                tanks[i].enabled = false;
            }
        }
        if (PlayerHit.playerHp <= 0)
        {
            deadPlayer = Instantiate(deadPlayer, transform.position, deadPlayer.transform.rotation);
            Destroy(gameObject);
        }
    }
}
