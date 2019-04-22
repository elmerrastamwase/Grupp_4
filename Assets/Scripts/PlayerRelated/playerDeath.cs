using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerDeath : MonoBehaviour
{
    public string sceneToLoad;

    void Update()
    {
        if (PlayerHP.playerHp <= 0)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
