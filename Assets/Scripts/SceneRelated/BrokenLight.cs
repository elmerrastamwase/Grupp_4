using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenLight : MonoBehaviour
{

    public Light bLight;
    public float timer;
    public int onOff;

    // Start is called before the first frame update
    void Start()
    {
        bLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            onOff = Random.Range(2,-1);
            timer = 0.1f;
        }

        if(onOff == 1)
        {
            bLight.enabled = true;
        } else { bLight.enabled = false; }
    }
}
