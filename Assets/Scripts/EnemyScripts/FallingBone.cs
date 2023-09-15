using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBone : MonoBehaviour
{

    [SerializeField]
    private int pointValue = 200;
    GameObject player;
    private SpriteRenderer playerSpriteRenderer;

    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite leftCorpse;
    [SerializeField]
    private AudioClip audioClip;
    private Color corpseColor = Color.white;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
        }
        corpseColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {

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
                if (Rubble) Rubble.GetComponent<Rubble>().SetAttributes(leftCorpse, corpseColor, new Vector2((Mathf.Sign(transform.localScale.x) * -200), 300));
                if (audioClip) ControllerScript.Controller.PlaySound(audioClip);
                
            }

        }
        if (other.gameObject.CompareTag("KillWall")) {
            Object.Destroy(this.gameObject);
        }
    }
}
