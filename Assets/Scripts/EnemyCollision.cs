using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollision : MonoBehaviour

{

    [SerializeField]
    private bool colorIsA = true;

    [SerializeField]
    private SpriteRenderer playerSpriteRenderer;

    [SerializeField]
    private PlayerColorChange playerColorChange;

    private SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (colorIsA) {
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
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                Object.Destroy(this.gameObject);
            }
            
        }
    }
}
