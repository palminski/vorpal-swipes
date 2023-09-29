using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{



    private void FixedUpdate()
    {

        gameObject.transform.position -= new Vector3(0, ControllerScript.Controller.finalSinkSpeed, 0);

    }
}
