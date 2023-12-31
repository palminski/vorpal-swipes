using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    public static void Fade(SpriteRenderer spriteRenderer) {
        Color newColor = spriteRenderer.color;
        newColor.a -= 0.03f;
        spriteRenderer.color = newColor;
    }

    public static void Fade(SpriteRenderer spriteRenderer, float fadeSpeed) {
        Color newColor = spriteRenderer.color;
        newColor.a -= fadeSpeed;
        spriteRenderer.color = newColor;
    }

    public static void ResetColor(SpriteRenderer spriteRenderer) {
        Color newColor = spriteRenderer.color;
        newColor.a = 1f;
        spriteRenderer.color = newColor;
    }

    public static void SnapToGrid(Transform transform) {
        var currentPosition = transform.position;
        transform.position = new Vector3(Mathf.Round(currentPosition.x),Mathf.Round(currentPosition.y),Mathf.Round(currentPosition.z));
    }

    public static Color ConvertColorHTML(Color colorToConvert) {

        ColorUtility.TryParseHtmlString("#"+ColorUtility.ToHtmlStringRGB(colorToConvert), out colorToConvert);
        
        return colorToConvert;
    }
    

}
