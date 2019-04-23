using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public float speed;
    public Transform target;

    // Update is called once per frame
    private void Awake()
    {
        
    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = 
            Vector2.MoveTowards(GetComponent<Rigidbody2D>().velocity, Vector2.zero, 2 * Time.deltaTime);

        GameObject PlayerFinder = GameObject.Find("Player");
        target = PlayerFinder.transform;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
       
        if (collision.tag == "Player")
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }
}