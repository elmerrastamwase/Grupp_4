using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleContoller : MonoBehaviour
{
    
    public ParticleSystem BubbleOnHit;
    public ParticleSystem DashBubble;
    public ParticleSystem FlotingBubble;

    void Awake()
    {
        FlotingBubble.Play(true);
    }

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

    
}
