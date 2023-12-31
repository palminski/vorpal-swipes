using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BreakableCollision : MonoBehaviour

{

    [SerializeField]
    private bool startColorIsA = true;
    
    [SerializeField]
    private bool waitUntilStart = false;

    [SerializeField]
    private bool unchanging = false;

    GameObject player;
    private SpriteRenderer playerSpriteRenderer;
    private PlayerColorChange playerColorChange;

    private Rigidbody2D playerRB;

    private SpriteRenderer spriteRenderer;

    private BoxCollider2D boxCollider;

    public Sprite BrokenPieceSprite;

    [SerializeField]
    private AudioClip audioClip;

   


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        
        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
            playerColorChange = player.GetComponent<PlayerColorChange>();
            playerRB = player.GetComponent<Rigidbody2D>();
        }
        if (unchanging) {
            return;
        }
        else if (waitUntilStart) {
            spriteRenderer.color = Color.white;
        }
        else if (startColorIsA) {
            spriteRenderer.color = playerColorChange.colorA;
        }
        else {
            spriteRenderer.color = playerColorChange.colorB;
        }

        
    }


    void FixedUpdate() {

        if (waitUntilStart == true && ControllerScript.Controller.SinkSpeed != 0) {
            spriteRenderer.color = playerSpriteRenderer.color;
            waitUntilStart = false;
        }

        if (playerSpriteRenderer.color != spriteRenderer.color) {
            boxCollider.usedByComposite = true;

        }
        else {
            boxCollider.usedByComposite = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Breaker") && playerRB.velocity != new Vector2(0,0))
        {

            if (audioClip) ControllerScript.Controller.PlaySound(audioClip);
            GameObject Rubble = PoolManager.PullFromPool("Rubble", transform.position, transform.rotation);
            if (Rubble) Rubble.GetComponent<Rubble>().SetAttributes(BrokenPieceSprite, spriteRenderer.color, new Vector2 (-200,300));
            GameObject Rubble2 = PoolManager.PullFromPool("Rubble", transform.position, Quaternion.Euler(Vector3.forward * 180));
            if (Rubble2) Rubble2.GetComponent<Rubble>().SetAttributes(BrokenPieceSprite, spriteRenderer.color, new Vector2 (200,300));
            
            Object.Destroy(this.gameObject);

        }
    }

}
