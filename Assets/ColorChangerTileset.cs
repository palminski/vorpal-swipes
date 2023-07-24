using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ColorChangerTileset : MonoBehaviour
{
    private Tilemap tilemap;
    
    private SpriteRenderer playerSpriteRenderer;

    private void OnEnable() {
        PlayerColorChange.OnColorChange += SwapColor;
    }

    private void OnDisable() {
        PlayerColorChange.OnColorChange -= SwapColor;
    }
    
    void SwapColor() {
        tilemap.color = playerSpriteRenderer.color;
    }

    void Start() {
        tilemap = GetComponent<Tilemap>();
        playerSpriteRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        SwapColor();

    }
}
