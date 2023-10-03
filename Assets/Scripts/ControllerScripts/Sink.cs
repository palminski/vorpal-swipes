using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{



    private void Update()
    {

        gameObject.transform.position -= new Vector3(0, ControllerScript.Controller.finalSinkSpeed * Time.deltaTime, 0);
        
    
    }
}
