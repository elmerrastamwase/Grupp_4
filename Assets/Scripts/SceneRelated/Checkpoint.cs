using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    private Gamemaster gm;
    public string sceneToLoad;
    public Transform Player;

    public void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<Gamemaster>();
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (other.CompareTag("Player"))
            {
                Gamemaster.lastCheckPointPos = transform.position;
            }
        }
    }

}
