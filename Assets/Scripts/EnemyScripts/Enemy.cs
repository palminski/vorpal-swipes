using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour

{

    [SerializeField]
    private int pointValue = 200;

    [SerializeField]
    private bool startColorIsA = true;

    GameObject player;
    private SpriteRenderer playerSpriteRenderer;
    private PlayerColorChange playerColorChange;

    [SerializeField]
    private SpriteRenderer spriteRendererToColor;

    private Color enemyColor;
    private Color corpseColor = Color.white;

    [SerializeField]
    private Sprite leftCorpse;
    [SerializeField]
    private Sprite rightCorpse;



    // Start is called before the first frame update
    void Start()
    {

        

        player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
            playerColorChange = player.GetComponent<PlayerColorChange>();
        }


        if (startColorIsA)
        {
            enemyColor = playerColorChange.colorA;
        }
        else
        {
            enemyColor = playerColorChange.colorB;
        }

        if (!spriteRendererToColor)
        {
            spriteRendererToColor = GetComponent<SpriteRenderer>();
            corpseColor = enemyColor;
        }
        spriteRendererToColor.color = enemyColor;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (playerSpriteRenderer.color != spriteRendererToColor.color)
            {
                ControllerScript.Controller.GameOver();
            }
            else
            {
                Object.Destroy(this.gameObject);
                ControllerScript.Controller.IncreaseScore(pointValue);

                GameObject Rubble = PoolManager.PullFromPool("Rubble", transform.position, transform.rotation, transform.localScale);
                if (Rubble) Rubble.GetComponent<Rubble>().SetAttributes(leftCorpse, corpseColor, new Vector2((Mathf.Sign(transform.localScale.x)*-200), 300));
                GameObject Rubble2 = PoolManager.PullFromPool("Rubble", transform.position, transform.rotation, transform.localScale);
                if (Rubble2) Rubble2.GetComponent<Rubble>().SetAttributes(rightCorpse, corpseColor, new Vector2((Mathf.Sign(transform.localScale.x)*200), 300));

                GameObject blood = PoolManager.PullWithoutRotation("Blood", transform.position);
                if (blood) blood.GetComponent<BloodScript>().Splatter();
            }

        }
    }

    private void OnDrawGizmos()
    {
        if (startColorIsA)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.magenta;
        }
        Gizmos.DrawWireSphere(transform.position, 1f);

    }
}