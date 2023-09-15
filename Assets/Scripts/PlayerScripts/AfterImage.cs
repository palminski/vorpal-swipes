using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AfterImage : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer playerSpriteRenderer;

    [Range(0.01f,1f)]
    public float fadeSpeed = 0.03f;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerSpriteRenderer = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();
        
            Utilities.ResetColor(spriteRenderer);
            SwapColor();
    }

    void OnEnable()
    {
        PlayerColorChange.OnColorChange += SwapColor;
        if (spriteRenderer)
        {
            
            Utilities.ResetColor(spriteRenderer);
            SwapColor();
        }
        
    }

    private void OnDisable()
    {
        PlayerColorChange.OnColorChange -= SwapColor;
    }

    void SwapColor()
    {
        Color newColor = playerSpriteRenderer.color;
        newColor.a = spriteRenderer.color.a;
        spriteRenderer.color = newColor;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Utilities.Fade(spriteRenderer,fadeSpeed);
        if (spriteRenderer.color.a <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
