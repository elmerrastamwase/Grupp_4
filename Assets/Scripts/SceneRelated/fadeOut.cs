using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeOut : MonoBehaviour
{


    public Image darkness;
    private float dTimer;
    public bool active;


    void Start()
    {
        dTimer = 10;
        active = false;
        darkness.color = new Color(0, 0, 0, 1);
    }
    private void Update()
    {
        
            if (dTimer > 0)
            {
                dTimer--;
                darkness.color = new Color(0, 0, 0,   (dTimer * 0.1f));
            }
 
        
    }
}
