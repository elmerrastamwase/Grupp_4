using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleContoller : MonoBehaviour
{
    
    public ParticleSystem BubbleOnHit;
    public ParticleSystem DashBubble;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DashBubble.Play();
        }
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            BubbleOnHit.Play();
        }
    }

}
