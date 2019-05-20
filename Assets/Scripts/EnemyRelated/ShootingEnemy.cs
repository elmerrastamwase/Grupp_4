using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
  

    private float timebtwshoots;
    public float starttimebtwshoots;

    public GameObject bullet;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;

        timebtwshoots = starttimebtwshoots;
    }

    // Update is called once per frame
    void Update()
    {
        if (timebtwshoots <= 0)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            timebtwshoots = starttimebtwshoots;
        }
        else
        {
            timebtwshoots -= Time.deltaTime;


        }
    }
}
