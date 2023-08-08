using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SwapTextColor : MonoBehaviour
{
    private TextMeshProUGUI thisText;
    
    private SpriteRenderer playerSpriteRenderer;

    private void OnEnable() {
        PlayerColorChange.OnColorChange += SwapColor;
    }

    private void OnDisable() {
        PlayerColorChange.OnColorChange -= SwapColor;
    }
    
    void SwapColor() {
        thisText.color = playerSpriteRenderer.color;
    }

    void Start() {
        thisText = GetComponent<TextMeshProUGUI>();
        playerSpriteRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        SwapColor();
    }
}
