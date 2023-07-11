using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private string target;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("touching");
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(target);
        }
    }
}
