using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class afterWin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        gameWin.winGame = false;
        Gamemaster.lastCheckPointPos = new Vector2(0, 0);
        chesetCount.chestPoint = 0;
        CD1.isTaken1 = false;
        CD1.isTaken2 = false;
        CD1.isTaken3 = false;
        CD1.isTaken4 = false;
    }
}
