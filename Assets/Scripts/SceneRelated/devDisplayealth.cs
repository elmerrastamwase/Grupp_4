using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class devDisplayealth : MonoBehaviour
{

    public TextMeshProUGUI healthDisplayed;

    void Start()
    {
        healthDisplayed = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        healthDisplayed.text = PlayerHit.playerHp.ToString();

        turnOnOffDisplay();
    }

    public void turnOnOffDisplay()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (healthDisplayed.enabled == true)
            {
                healthDisplayed.enabled = false;
            }
            else if (healthDisplayed.enabled == false)
            {
                healthDisplayed.enabled = true;
            }
        }
    }
}
