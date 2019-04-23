using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timedkiller : MonoBehaviour
{
    public string sceneToLoad = ("Felix.sandbox");
    public float startkilltimer =1;
    public float killtimer =1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (killtimer <= 0)
        {
            SceneManager.LoadScene(sceneToLoad);
        }

        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
       if (killtimer >= 0)
        {
            killtimer -= Time.deltaTime;
        }  
    }
    
         
    




    private void OnCollisionExit2D(Collision2D collision)
    {
          killtimer = startkilltimer;
    }
    
        
      
    
    
    
                  
        
  
   
    
    

}
