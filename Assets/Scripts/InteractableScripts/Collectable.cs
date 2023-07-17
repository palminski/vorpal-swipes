using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    [SerializeField]
    private int pointValue = 100;
    [SerializeField]
    private int coinValue = 1;

    private Transform playerTransform;

[SerializeField]
    private float magneticDist = 3;

    private void Start () {
        playerTransform = GameObject.Find("Player").transform;
    }

    private void Update () {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        if (distanceToPlayer < magneticDist) {
            float speed = magneticDist-distanceToPlayer;
            speed = speed * Time.deltaTime * 0.5f;

            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Object.Destroy(this.gameObject);
            ControllerScript.Controller.IncreaseScore(pointValue);
            ControllerScript.Controller.IncreaseCoins(coinValue);
        }
    }
}
