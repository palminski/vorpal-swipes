using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenBlock : MonoBehaviour
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

    public void OnActivate(Color color, Vector2 force) {
        
        rb.AddForce(force);
        spriteRenderer.color = color;
    }

}
