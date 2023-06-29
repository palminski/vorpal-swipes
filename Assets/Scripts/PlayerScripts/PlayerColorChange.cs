using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerColorChange : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    
    public Light2D playerLight;

    [SerializeField]
    private Color colorA = Color.green;
    [SerializeField]
    private Color colorB = Color.magenta;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = colorA;
        playerLight.color = colorA;
    }

    public void SwapColor() {
        if (spriteRenderer.color == colorA) {
            spriteRenderer.color = colorB;
        }
        else {
            spriteRenderer.color = colorA;
        }
        playerLight.color = spriteRenderer.color;
    }

}
