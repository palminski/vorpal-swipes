using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    public GameObject player;

    private SpriteRenderer playerSpriteRenderer;

    private PlayerColorChange playerColorChange;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
        playerColorChange = player.GetComponent<PlayerColorChange>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            if (playerColorChange.colorA != spriteRenderer.color && playerColorChange.colorB != spriteRenderer.color) {
                playerColorChange.SetNewColor(spriteRenderer.color);
            }

        }
    }
}
