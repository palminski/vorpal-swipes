using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TitleScreenPlayer : MonoBehaviour
{

    private Color color = Color.green;
    private SpriteRenderer spriteRenderer;

    public Light2D playerLight;
    // Start is called before the first frame update
    void Awake()
    {

        ColorUtility.TryParseHtmlString("#"+PlayerPrefs.GetString("colorA","07FF00"), out color);
        // ColorUtility.TryParseHtmlString("#"+PlayerPrefs.GetString("colorB","F000FF"), out color);

        spriteRenderer = GetComponent<SpriteRenderer>();
        
        spriteRenderer.color = color;
        playerLight.color = color;
    }


}
