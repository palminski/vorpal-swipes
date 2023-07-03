using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerColorChange : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private TrailRenderer trail;
    public Light2D playerLight;

    [SerializeField]
    private Color colorA = Color.green;
    [SerializeField]
    private Color colorB = Color.magenta;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        trail = GetComponent<TrailRenderer>();
        spriteRenderer.color = colorA;
        playerLight.color = colorA;
        trail.startColor = colorA;
        var tempColor = colorA;
        tempColor.a = 0;
        trail.endColor = tempColor;
    }

    public void SwapColor() {
        Color colorToSwapTo;
        if (spriteRenderer.color == colorA) {
            colorToSwapTo = colorB;
            
            
        }
        else {
            colorToSwapTo = colorA;

        }
        spriteRenderer.color = colorToSwapTo;
            trail.startColor = colorToSwapTo;
            colorToSwapTo.a = 0;
            trail.endColor = colorToSwapTo;

        playerLight.color = spriteRenderer.color;
    }

}
