using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorChange : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    
    [SerializeField]
    private Color colorA = Color.green;
    [SerializeField]
    private Color colorB = Color.magenta;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = colorA;
    }

    public void SwapColor() {
        if (spriteRenderer.color == colorA) {
            spriteRenderer.color = colorB;
        }
        else {
            spriteRenderer.color = colorA;
        }
    }

}
