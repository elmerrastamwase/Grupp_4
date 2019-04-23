using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxEffect : MonoBehaviour
{
    private float legth;
    public float parallax;
    public GameObject camra;
    private float Startpos = 1;
    public float smooth;
   
   
    void Start()
    {
        Startpos = (transform.position.x +- transform.position.y);
        
        legth = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    private void FixedUpdate ()
    {
      
        float dist = camra.transform.position.x * (parallax );
        

        transform.position = new Vector3(Startpos + dist, transform.position.y, transform.position.z) ;
    }
   
    
        
  
        
        

       
    
  


}

