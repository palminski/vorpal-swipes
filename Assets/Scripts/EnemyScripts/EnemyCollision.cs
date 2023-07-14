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

    [SerializeField]
    private Sprite leftCorpse;
    [SerializeField]
    private Sprite rightCorpse;


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


        if (startColorIsA)
        {
            spriteRenderer.color = playerColorChange.colorA;
        }
        else
        {
            spriteRenderer.color = playerColorChange.colorB;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (playerSpriteRenderer.color != spriteRenderer.color)
            {
                ControllerScript.Controller.GameOver();
            }
            else
            {

                Object.Destroy(this.gameObject);
                ControllerScript.Controller.IncreaseScore(pointValue);

                GameObject Rubble = PoolManager.PullFromPool("Rubble", transform.position, transform.rotation, transform.localScale);
                Rubble.GetComponent<Rubble>().SetAttributes(leftCorpse, spriteRenderer.color, new Vector2(-200, 300));
                GameObject Rubble2 = PoolManager.PullFromPool("Rubble", transform.position, transform.rotation, transform.localScale);
                Rubble2.GetComponent<Rubble>().SetAttributes(rightCorpse, spriteRenderer.color, new Vector2(200, 300));

                GameObject blood = PoolManager.PullWithoutRotation("Blood", transform.position);
                blood.GetComponent<BloodScript>().Splatter();

                
            }

        }
    }
}
