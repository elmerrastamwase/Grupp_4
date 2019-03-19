using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public static int maxPlayerHp = 5;
    public static int playerHp = 5;
    public static bool hasIFrames;
    public int iFrames = 60;

    public Image[] tanks;
    public Sprite fullTank;
    public Sprite emptyTank;

    void Update()
    {
        if (playerHp > maxPlayerHp)
        {
            playerHp = maxPlayerHp;
        }

        if (playerHp <= 0)
        {

        }

        //if (hasIFrames == true)
        //{
        //    iFrames -= 1;
        //    if (iFrames < 1)
        //    {
        //        hasIFrames = false;
        //        iFrames = 60;
        //    }
        //}
        //for (int i = 0; i < tanks.Length; i++)
        //{
        //    if(i < playerHp){
        //        tanks[i].sprite = fullTank;
        //    }else{
        //        tanks[i].sprite = emptyTank;
        //    }

        //    if (i < maxPlayerHp){
        //        tanks[i].enabled = true;
        //    }else{
        //        tanks[i].enabled = false;
        //    }
        //}
    }
}
