using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnlockWithCoins : MonoBehaviour
{
    GameObject player;
    private Rigidbody2D playerRB;

    private BoxCollider2D boxCollider;

    [SerializeField]
    private int unlockCost = 100;

    
    private TextMeshProUGUI lockText;

    [SerializeField]
    private bool isPermanent = true;

    public string collectableStringKey = "default";

    [SerializeField]
    private Sprite BrokenPieceSprite;

    [SerializeField]
    private AudioClip BreakingNoise;


    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        player = GameObject.FindWithTag("Player");
        lockText = GetComponentInChildren<TextMeshProUGUI>();
        lockText.text = unlockCost.ToString();

        if (player != null)
        {

            playerRB = player.GetComponent<Rigidbody2D>();
        }

        //If opened already delete self
        if (ControllerScript.Controller.CollectedItems.Contains(collectableStringKey)) {
            Object.Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (ControllerScript.Controller.CollectedCoins >= unlockCost) {
            boxCollider.isTrigger = true;
        }
        else {
            boxCollider.isTrigger = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Breaker") && playerRB.velocity != new Vector2(0,0))
        {
            if (BreakingNoise) ControllerScript.Controller.PlaySound(BreakingNoise);
            ControllerScript.Controller.addCoins(-unlockCost);
            if (isPermanent) ControllerScript.Controller.addCollectableItem(collectableStringKey);
            GameObject Rubble = PoolManager.PullFromPool("Rubble", transform.position, Quaternion.Euler(Random.Range(0f,360f),Random.Range(0f,360f),Random.Range(0f,360f)));
            if (Rubble) Rubble.GetComponent<Rubble>().SetAttributes(BrokenPieceSprite, Color.white, new Vector2 (Random.Range(0f,360f),Random.Range(0f,360f)));
            GameObject Rubble2 = PoolManager.PullFromPool("Rubble", transform.position, Quaternion.Euler(Random.Range(0f,360f),Random.Range(0f,360f),Random.Range(0f,360f)));
            if (Rubble2) Rubble2.GetComponent<Rubble>().SetAttributes(BrokenPieceSprite, Color.white, new Vector2 (Random.Range(0f,360f),Random.Range(-360f,0f)));
            GameObject Rubble3 = PoolManager.PullFromPool("Rubble", transform.position, Quaternion.Euler(Random.Range(0f,360f),Random.Range(0f,360f),Random.Range(0f,360f)));
            if (Rubble3) Rubble3.GetComponent<Rubble>().SetAttributes(BrokenPieceSprite, Color.white, new Vector2 (Random.Range(-360f,0f),Random.Range(0f,360f)));
            GameObject Rubble4 = PoolManager.PullFromPool("Rubble", transform.position, Quaternion.Euler(Random.Range(0f,360f),Random.Range(0f,360f),Random.Range(0f,360f)));
            if (Rubble4) Rubble4.GetComponent<Rubble>().SetAttributes(BrokenPieceSprite, Color.white, new Vector2 (Random.Range(-360f,0f),Random.Range(-360f,0f)));
            Object.Destroy(this.gameObject);

        }
    }
}
