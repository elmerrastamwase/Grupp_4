using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class chesetCount : MonoBehaviour
{

    public static int chestPoint;
    public static bool hasTakenChest;
    public GameObject SFX;
    public TextMeshProUGUI text;

    private void Start()
    {
     
            hasTakenChest = false;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasTakenChest == false)
            if (collision.tag == "Chest")
            {
                hasTakenChest = true;
                Destroy(collision.gameObject);
                chestPoint += 1;
                SFX = Instantiate(SFX, transform.position, SFX.transform.rotation);
            }
    }
    private void Update()
    {
        text.SetText($"{chestPoint} / 5");
    }
}
