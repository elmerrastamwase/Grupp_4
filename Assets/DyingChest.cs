using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingChest : MonoBehaviour
{
    public float shakeTimer;
    public Vector2 center;
    public float dTimer;
    public ParticleSystem splinters;
    public ParticleSystem coin;
    public GameObject splinterSFX;
    public GameObject coinSFX;

    private void Start()
    {
        dTimer = 3;
        center = chestDamage.chestLocation;
    }
    // Update is called once per frame
    void Update()
    {
        
        if (shakeTimer > 0) shakeTimer -= Time.deltaTime;
        else
        {
            transform.Translate(Random.Range(-.5f, 1.5f), Random.Range(-.5f, 1.5f), 0);
            shakeTimer = 0.03f;
            if (splinters.isPlaying == false)
            {
                splinterSFX = Instantiate(splinterSFX, transform.position, splinterSFX.transform.rotation);
                ParticleSystem particle = Instantiate(splinters, transform.position, splinters.transform.rotation);
                Destroy(particle, splinters.main.duration);
            }
        }
        if (transform.position.x > center.x + .5f || transform.position.x < center.x - .5f ||
            transform.position.y > center.y + .5f || transform.position.y < center.y - .5f)
            transform.position = center;
        dTimer -= Time.deltaTime;
        if (dTimer <= 0)
        {
            coinSFX = Instantiate(coinSFX, transform.position, coinSFX.transform.rotation);
            ParticleSystem particle = Instantiate(coin, transform.position, coin.transform.rotation);
            Destroy(particle, coin.main.duration);
            Destroy(gameObject);
        }


    }
}
