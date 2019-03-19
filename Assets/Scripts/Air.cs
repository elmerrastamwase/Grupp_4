using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("bar");
    }
    private Transform bar;
    public static int air;

    public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(air / 100, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        bar.localScale = new Vector3(1,air / 100f);
        Debug.Log(air);
        if (air >= 100)
        {
            air = 0;
            PlayerHP.playerHp += 1;
        }
    }
}
