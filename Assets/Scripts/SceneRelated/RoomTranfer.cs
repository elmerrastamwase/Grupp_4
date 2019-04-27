using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomTranfer : MonoBehaviour
{
    public string sceneName;
    public float xPosition;
    public float yPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("door");
            Gamemaster.lastCheckPointPos = new Vector2(xPosition, yPosition);
           SceneManager.LoadScene(sceneName);
        }
    } 
}
