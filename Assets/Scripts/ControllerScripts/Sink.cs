using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{

    private void FixedUpdate()
    {
        gameObject.transform.position -= new Vector3(0, GlobalVariables.Variables.SinkSpeed, 0);
    }
}
