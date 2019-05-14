using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public static int maxPlayerHp = 5;
    public static int playerHp;
    public static bool hasIFrames;
    public float iFrames = 2;
    private Gamemaster gm;
    public Image[] tanks;
    public Sprite fullTank;
    public Sprite emptyTank;
    public SpriteRenderer player;
    public GameObject deadPlayer;

    public void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string currentSceneName = currentScene.name;

        if (currentSceneName == "Tutorial")
        {
            playerHp = maxPlayerHp;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (playerHp > maxPlayerHp)
        {
            playerHp = maxPlayerHp;
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
            if (i < playerHp)
            {
                tanks[i].sprite = fullTank;
            }
            else
            {
                tanks[i].sprite = emptyTank;
            }

            if (i < maxPlayerHp)
            {
                tanks[i].enabled = true;
            }
            else
            {
                tanks[i].enabled = false;
            }
        }
        if (playerHp <= 0)
        {
            deadPlayer = Instantiate(deadPlayer, transform.position, deadPlayer.transform.rotation);
            Destroy(gameObject);
        }
    }
}
