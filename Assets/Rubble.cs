using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubble : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
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

    public void SetAttributes(Sprite sprite, Color color, Vector2 force) {
        
        spriteRenderer.sprite = sprite;
        rb.AddForce(force);
        spriteRenderer.color = color;
    }

}
