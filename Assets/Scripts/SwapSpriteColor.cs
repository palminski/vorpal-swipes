using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapSpriteColor : MonoBehaviour
{
    private SpriteRenderer thisSprite;
    
    private SpriteRenderer playerSpriteRenderer;

    private void OnEnable() {
        PlayerColorChange.OnColorChange += SwapColor;
    }

    private void OnDisable() {
        PlayerColorChange.OnColorChange -= SwapColor;
    }
    
    void SwapColor() {
        thisSprite.color = playerSpriteRenderer.color;
    }

    void Start() {
        thisSprite = GetComponent<SpriteRenderer>();
        playerSpriteRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        SwapColor();
    }
}
