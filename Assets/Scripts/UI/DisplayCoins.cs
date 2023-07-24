using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayCoins : MonoBehaviour
{

    private TextMeshProUGUI coinText;
    
    private SpriteRenderer playerSpriteRenderer;

    private void OnEnable() {
        PlayerColorChange.OnColorChange += SwapColor;
    }

    private void OnDisable() {
        PlayerColorChange.OnColorChange -= SwapColor;
    }
    
    void SwapColor() {
        coinText.color = playerSpriteRenderer.color;
    }

    void Start() {
        coinText = GetComponent<TextMeshProUGUI>();
        playerSpriteRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        SwapColor();
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coins: "+ ControllerScript.Controller.CollectedCoins;
    }
}
