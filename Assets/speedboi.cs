using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedboi : MonoBehaviour
{
    

    
    void Update()
    {
        transform.Translate(new Vector3(0.05f*transform.rotation.z,-0.05f,0));
    }
}
