using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private string target;

    [SerializeField]
    private string enterPosition = "center";
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("touching");
        if (other.gameObject.CompareTag("Player"))
        {
            StaticVars.setEntryPosition(enterPosition);
            SceneManager.LoadScene(target);
        }
    }
}
