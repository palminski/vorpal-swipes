using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockWithCoins : MonoBehaviour
{
    GameObject player;
    private Rigidbody2D playerRB;

    private BoxCollider2D boxCollider;

    [SerializeField]
    private int unlockCost = 100;

    public string collectableStringKey = "default";


    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        player = GameObject.FindWithTag("Player");
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
            
            ControllerScript.Controller.addCoins(-unlockCost);
            ControllerScript.Controller.addCollectableItem(collectableStringKey);
            
            Object.Destroy(this.gameObject);

        }
    }
}
