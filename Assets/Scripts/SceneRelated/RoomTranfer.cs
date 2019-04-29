using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoomTranfer : MonoBehaviour
{
    public string sceneName;
    public float xPosition;
    public float yPosition;
    public Image darkness;
    private float dTimer;
    public bool active;


    void Start()
    {
        dTimer = 10;
        active = false;
    }
    private void Update()
    {
        if (active == true)
        {
            if (dTimer > 0)
            {
                dTimer--;
                darkness.color = new Color(0, 0, 0, 1 - (dTimer * 0.1f));
            }
            else
            {
                PlayerHP.playerHp = 5;
                dTimer = 75;
                Gamemaster.lastCheckPointPos = new Vector2(xPosition, yPosition);
                SceneManager.LoadScene(sceneName);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            active = true;
        }
    } 
}
