using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleContoller : MonoBehaviour
{
    public ParticleSystem DashParticle;
    public ParticleSystem JumpParticle;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DashParticle.Play();
        }
    }
}
