using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class displayHealth : MonoBehaviour
{
    public TextMeshProUGUI healthDisplay;

    private void Start()
    {
        healthDisplay = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        healthDisplay.text = PlayerHP.playerHp.ToString();
    }
}
