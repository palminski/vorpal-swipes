using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{

    ManageSinkSpeed manageSinkSpeed;
    GameObject controller;

    void Awake()
    {
        controller = GameObject.FindWithTag("Controller");
        if (controller != null)
        {
            manageSinkSpeed = controller.GetComponent<ManageSinkSpeed>();
        }
    }

    private void FixedUpdate()
    {
        gameObject.transform.position -= new Vector3(0, manageSinkSpeed.sinkSpeed, 0);
    }
}
