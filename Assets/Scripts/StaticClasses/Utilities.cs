using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    public static void Fade(SpriteRenderer spriteRenderer) {
        Color newColor = spriteRenderer.color;
        newColor.a -= 0.01f;
        spriteRenderer.color = newColor;
    }
}
