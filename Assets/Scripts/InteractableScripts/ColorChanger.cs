using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private GameObject player;
    private PlayerColorChange playerColorChange;

    private Color colorToBestow;
    [SerializeField][Range(0, 1)] private float fadedAlpha = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerColorChange = player.GetComponent<PlayerColorChange>();

        //This converts the color to an HTML RGB string and back so that it matches the process dont to the player pref colors and prevents very slight color variatoins making player essentially able to be same color twice'
        spriteRenderer.color = Utilities.ConvertColorHTML(spriteRenderer.color);

        colorToBestow = spriteRenderer.color;
    }

    void FixedUpdate()
    {
        Color newColor = colorToBestow;
        if (playerColorChange.colorA != colorToBestow && playerColorChange.colorB != colorToBestow)
        {
            newColor.a = fadedAlpha;
        }
        else
        {
            newColor.a = 1;
        }
        spriteRenderer.color = newColor;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            if (playerColorChange.colorA != colorToBestow && playerColorChange.colorB != colorToBestow)
            {
                playerColorChange.SetNewColor(colorToBestow);
            }

        }
    }




}
