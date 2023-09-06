using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using System;

public class PlayerColorChange : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    
    public Light2D playerLight;

    private PlayerDeath playerDeath;

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
        playerDeath = GetComponent<PlayerDeath>();

        if (StaticVars.lastColor == colorB) {
            spriteRenderer.color = colorB;
        }
        else {
            spriteRenderer.color = colorA;
        }
        
        playerLight.color = spriteRenderer.color;
        
    }

    public void SwapColor() {
        if (Time.timeScale == 0 || playerDeath.playerDead) return;
        Color colorToSwapTo;

        if (spriteRenderer.color == colorA) {
            colorToSwapTo = colorB;
        }
        else {
            colorToSwapTo = colorA;
        }
        spriteRenderer.color = colorToSwapTo;
            

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

        playerLight.color = spriteRenderer.color;

        //Color Change Action
        OnColorChange?.Invoke();

    }

}
