using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteIfCollected : MonoBehaviour
{
    [SerializeField]
    private string collectableStringKey = "";

    [SerializeField]
    private int requiredScore = 100000;
    // Start is called before the first frame update
    void Start()
    {
        if (ControllerScript.Controller.CollectedItems.Contains(collectableStringKey) || ControllerScript.Controller.Score < requiredScore)
        {
            Object.Destroy(this.gameObject);
        }
    }

}
