using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustTrail : MonoBehaviour
{

    private TrailRenderer trailRenderer;

    // Start is called before the first frame update
    void Start()
    {
        trailRenderer = GetComponent<TrailRenderer>();

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        for (int i = 0; i < trailRenderer.positionCount; i++) {
            trailRenderer.SetPosition(i, trailRenderer.GetPosition(i) - new Vector3(0,ControllerScript.Controller.SinkSpeed,0));
        }
    }
}