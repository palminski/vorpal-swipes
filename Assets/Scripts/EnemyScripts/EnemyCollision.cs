using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyCollision : MonoBehaviour

{

    [SerializeField]
    private int pointValue = 200;

    [SerializeField]
    private bool startColorIsA = true;

    GameObject player;
    private SpriteRenderer playerSpriteRenderer;
    private PlayerColorChange playerColorChange;

    private SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
            playerColorChange = player.GetComponent<PlayerColorChange>();
        }


        if (startColorIsA) {
            spriteRenderer.color = playerColorChange.colorA;
        }
        else {
            spriteRenderer.color = playerColorChange.colorB;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (playerSpriteRenderer.color != spriteRenderer.color) {
                ControllerScript.Controller.GameOver();
            }
            else
            {
                Object.Destroy(this.gameObject);
                ControllerScript.Controller.IncreaseScore(pointValue);
            }
            
        }
    }
}
