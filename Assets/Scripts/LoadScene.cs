using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneToLoad;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    public void sceneLoad()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
