using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : MonoBehaviour
{
    [SerializeField]
    private string collectableStringKey = "";

    // Start is called before the first frame update
    void Start()
    {
        if (!ControllerScript.Controller.CollectedItems.Contains(collectableStringKey)) {
            Object.Destroy(this.gameObject);
        }
    }

}
