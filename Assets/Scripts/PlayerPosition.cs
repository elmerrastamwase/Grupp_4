using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public Transform playerTransform;

    public void Start()
    {
        playerTransform = GetComponent<Transform>();
    }
}
