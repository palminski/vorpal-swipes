using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockWithAllKeys : MonoBehaviour
{
    [SerializeField]
    private int requiredScore = 200000;
    void Start()
    {
        if (
            ControllerScript.Controller.CollectedItems.Contains("RedKey")
            && ControllerScript.Controller.CollectedItems.Contains("BlueKey")
            && ControllerScript.Controller.CollectedItems.Contains("YellowKey")
            && ControllerScript.Controller.CollectedItems.Contains("PurpleKey")
            && ControllerScript.Controller.CollectedItems.Contains("GreenKey")
            && ControllerScript.Controller.CollectedItems.Contains("OrangeKey")
            && ControllerScript.Controller.Score >= requiredScore
        )
        {
            Object.Destroy(this.gameObject);
        }
    }
}
