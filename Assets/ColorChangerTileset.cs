using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ColorChangerTileset : MonoBehaviour
{
    private Tilemap tilemap;
    
    [SerializeField]
    private float fadeLimit = 0.25f;

    [SerializeField]
    private float fadePerStep = 0.01f;
    private SpriteRenderer playerSpriteRenderer;

    private void OnEnable() {
        PlayerColorChange.OnColorChange += SwapColor;
    }

    private void OnDisable() {
        PlayerColorChange.OnColorChange -= SwapColor;
    }
    
    void FixedUpdate() {
        if (tilemap.color.a > fadeLimit) {
            Color newColor = tilemap.color;
            newColor.a -= fadePerStep;
            tilemap.color = newColor;
        }
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
