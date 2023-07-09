using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    [SerializeField]
    private int pointValue = 100;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Object.Destroy(this.gameObject);
            GlobalVariables.Variables.IncreaseScore(pointValue);
        }
    }
}
