using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemaster : MonoBehaviour
{
    private static Gamemaster Level;

    void Awake()
    {
        if (Level == null)
        {
            Level = this;
            DontDestroyOnLoad(Level);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
