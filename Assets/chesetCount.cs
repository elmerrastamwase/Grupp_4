using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class chesetCount : MonoBehaviour
{

    public static int chestPoint;
    public bool hasTakenChest;

    public TextMeshProUGUI text;

    private void Start()
    {
        hasTakenChest = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Chest")
        {
            Destroy(collision.gameObject);
            chestPoint += 1;
            text.SetText($"{chestPoint} / 5");
        }
    }
}
