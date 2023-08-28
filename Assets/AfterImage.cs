using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AfterImage : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer playerSpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerSpriteRenderer = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        PlayerColorChange.OnColorChange += SwapColor;
        if (spriteRenderer)
        {
            spriteRenderer.sprite = playerSpriteRenderer.sprite;
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
        spriteRenderer.color = playerSpriteRenderer.color;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Utilities.Fade(spriteRenderer);
        if (spriteRenderer.color.a <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
