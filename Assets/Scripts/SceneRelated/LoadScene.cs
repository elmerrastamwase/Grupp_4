using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public string sceneToLoad;
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
                dTimer = 10;
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            sceneLoad();
        }
    }

    public void sceneLoad()
    {
        active = true;
    }

    public void creditsScene()
    {
        SceneManager.LoadScene(2);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(3);
    }
}
