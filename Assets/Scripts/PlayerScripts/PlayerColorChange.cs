using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using System;

public class PlayerColorChange : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private TrailRenderer trail;
    public Light2D playerLight;

    [SerializeField]
    public Color colorA = Color.green;
    [SerializeField]
    public Color colorB = Color.magenta;

    public static event Action OnColorChange;

    private void Awake() {


        // colorA = PlayerPrefs.GetString("colorA","07FF00");
                // colorB = PlayerPrefs.GetString("colorB","F000FF");?

        ColorUtility.TryParseHtmlString("#"+PlayerPrefs.GetString("colorA","07FF00"), out colorA);
        ColorUtility.TryParseHtmlString("#"+PlayerPrefs.GetString("colorB","F000FF"), out colorB);

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
        if (Time.timeScale == 0) return;
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

        GameObject colorBurst = PoolManager.PullWithoutRotation("ColorBurst", transform.position);
        if (colorBurst) colorBurst.GetComponent<ColorChangeBurst>().ColorBurst(spriteRenderer.color);

        //Color Change Action
        OnColorChange?.Invoke();
        

        
    }

    public void SetNewColor(Color colorToSet)
    {
        
        //determine if we are currently color A or B
        if (spriteRenderer.color == colorA) {
            colorA = colorToSet;
            PlayerPrefs.SetString("colorA",ColorUtility.ToHtmlStringRGB(colorToSet));
        }
        else {
            colorB = colorToSet;
            PlayerPrefs.SetString("colorB",ColorUtility.ToHtmlStringRGB(colorToSet));
        }
        
        //strat by changing the players color
        spriteRenderer.color = colorToSet;
        trail.startColor = colorToSet;
        colorToSet.a = 0;
        trail.endColor = colorToSet;
        playerLight.color = spriteRenderer.color;

        //Color Change Action
        OnColorChange?.Invoke();

    }

}
