using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private RectTransform rt;

    private Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        if (ControllerScript.Controller.CollectedItems.Contains("VetranProof")) Object.Destroy(this.gameObject);
        rt = GetComponent<RectTransform>();
        scale = rt.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (ControllerScript.Controller.SinkSpeed == 0) {
            rt.localScale = new Vector3(0,0,0);
        }
        else {
            rt.localScale = scale;
        }
    }
}
