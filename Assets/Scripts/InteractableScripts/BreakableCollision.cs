using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BreakableCollision : MonoBehaviour

{

    [SerializeField]
    private bool startColorIsA = true;

    GameObject player;
    private SpriteRenderer playerSpriteRenderer;
    private PlayerColorChange playerColorChange;

    private Rigidbody2D playerRB;

    private SpriteRenderer spriteRenderer;

    private BoxCollider2D boxCollider;


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


        if (startColorIsA) {
            spriteRenderer.color = playerColorChange.colorA;
        }
        else {
            spriteRenderer.color = playerColorChange.colorB;
        }
    }


    void FixedUpdate() {
        if (playerSpriteRenderer.color != spriteRenderer.color) {
            boxCollider.isTrigger = false;
        }
        else {
            boxCollider.isTrigger = true;
        }
        
    }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         Debug.Log("Player Entered");
    //         Object.Destroy(this.gameObject);   
    //     }
    // }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == player && playerRB.velocity != new Vector2(0,0))
        {
            Debug.Log("Player Staying");
            Object.Destroy(this.gameObject); 
        }
    }

    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         Debug.Log("Player EXITED");
            
    //     }
    // }
}
