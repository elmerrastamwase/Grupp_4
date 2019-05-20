using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CD1 : MonoBehaviour
{
    public int chestNr;
    public static bool isTaken1;
    public static bool isTaken2;
    public static bool isTaken3;
    public static bool isTaken4;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (chestNr == 1)
                isTaken1 = true;
            if (chestNr == 2)
                isTaken2 = true;
            if (chestNr == 3)
                isTaken3 = true;
            if (chestNr == 4)
                isTaken4 = true;
        }
    }

    private void Update()
    {
        if (chestNr == 1)
            c1();
        if (chestNr == 2)
            c2();
        if (chestNr == 3)
            c3();
        if (chestNr == 4)
            c4();
    }

    void c1()
    {
        if (isTaken1 == true)
            Destroy(gameObject);
    }
    void c2()
    {
        if (isTaken2 == true)
            Destroy(gameObject);
    }
    void c3()
    {
        if (isTaken3 == true)
            Destroy(gameObject);
    }
    void c4()
    {
        if (isTaken4 == true)
            Destroy(gameObject);
    }
}
