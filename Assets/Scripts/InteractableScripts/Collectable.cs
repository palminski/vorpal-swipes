using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    [SerializeField]
    private int pointValue = 100;
    [SerializeField]
    private int coinValue = 1;
    [SerializeField]
    private float magneticDist = 3;

    [SerializeField]
    private bool isPermanentCollectable = false;
    [SerializeField]
    private string collectableStringKey = "";

    private Transform playerTransform;


    [SerializeField]
    private AudioClip audioClip;

    

    private void Start()
    {
        playerTransform = GameObject.Find("Player").transform;

    }

    private void Update()
    {
        if (playerTransform != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
            if (distanceToPlayer < magneticDist)
            {
                float speed = magneticDist - distanceToPlayer;
                speed = speed * Time.deltaTime * 2;

                transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed);
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (audioClip) ControllerScript.Controller.PlaySound(audioClip);
            Object.Destroy(this.gameObject);
            ControllerScript.Controller.IncreaseScore(pointValue);
            ControllerScript.Controller.addCoins(coinValue);

            if (isPermanentCollectable) {
                ControllerScript.Controller.addCollectableItem(collectableStringKey);
            }

            GameObject colorBurst = PoolManager.PullWithoutRotation("ColorBurst", transform.position);
            if (colorBurst) colorBurst.GetComponent<ColorChangeBurst>().ColorBurst(Color.yellow);
        }
    }
}
