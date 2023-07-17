using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayCoins : MonoBehaviour
{

    private TextMeshProUGUI coinText;
    
    void Awake() {
        coinText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coins: "+ ControllerScript.Controller.CollectedCoins;
    }
}
