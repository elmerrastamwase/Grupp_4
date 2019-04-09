using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleContoller : MonoBehaviour
{
    public ParticleSystem BubbleOnHit;
    void Start()
    {
        BubbleOnHit.Play();
    }

   /* void Update()
    {
        if ()
        {
            BubbleOnHit.Play
        }
    }
    */
}
