using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    private Gamemaster gm;
    public string sceneToLoad;
    public Transform Player;
    public Animator icon;
    public float timer;

    public void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<Gamemaster>();
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (other.CompareTag("Player"))
            {
                Gamemaster.lastCheckPointPos = transform.position;
                icon.SetBool("x", true);
                timer = 1;
            }
        }
    }

}
