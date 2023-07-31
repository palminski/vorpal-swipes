using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private GameObject player;

    private SpriteRenderer playerSpriteRenderer;

    private PlayerColorChange playerColorChange;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
        playerColorChange = player.GetComponent<PlayerColorChange>();

        //This converts the color to an HTML RGB string and back so that it matches the process dont to the player pref colors and prevents very slight color variatoins making player essentially able to be same color twice'
        spriteRenderer.color = (ConvertColorHTML(spriteRenderer.color));
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(playerColorChange.colorA + " " + playerColorChange.colorB);
            Debug.Log("this color: " + spriteRenderer.color);
            if (playerColorChange.colorA != spriteRenderer.color && playerColorChange.colorB != spriteRenderer.color)
            {
                Debug.Log("color changed");
                playerColorChange.SetNewColor(spriteRenderer.color);
            }

        }
    }

    private Color ConvertColorHTML(Color colorToConvert) {

        ColorUtility.TryParseHtmlString("#"+ColorUtility.ToHtmlStringRGB(colorToConvert), out colorToConvert);
        
        return colorToConvert;
    }
}
