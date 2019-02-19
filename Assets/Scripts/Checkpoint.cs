using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Gamemaster gm;

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
                gm.lastCheckPointPos = transform.position;
            }
        }
    }
}
