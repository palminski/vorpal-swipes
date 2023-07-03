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
        trail.endColor = colorA;
    }

    public void SwapColor() {
        if (spriteRenderer.color == colorA) {
            spriteRenderer.color = colorB;
            trail.startColor = colorB;
            trail.endColor = colorB;
        }
        else {
            spriteRenderer.color = colorA;
            trail.startColor = colorA;
            trail.endColor = colorA;
        }
        playerLight.color = spriteRenderer.color;
    }

}
