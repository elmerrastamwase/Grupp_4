using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameWin : MonoBehaviour
{
    public static bool winGame;
    public Image darkness;
    private int dTimer;
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        dTimer = 200;
        darkness.color = new Color(1, 1, 1, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (winGame == true)
            if (dTimer > 0)
            {

                dTimer--;
                darkness.color = new Color(1, 1, 1, 1 - (dTimer * 0.01333f));
            }
            else SceneManager.LoadScene(sceneName);
    }
}
