using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSideScroll : MonoBehaviour
{

    

    private float respawnHeight = 66;

    [SerializeField]
    private Transform respawnPoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        transform.position += new Vector3(0, ControllerScript.Controller.SinkSpeed, 0);

        if (transform.position.y > respawnHeight) {
            transform.position = respawnPoint.position;

        }
    }
}
