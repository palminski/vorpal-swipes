using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{
    public float sinkSpeed = 0.005f;
    // Start is called before the first frame update
    void Start()
    {
        //setting this temporarily while testing
        sinkSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        gameObject.transform.position -= new Vector3(0, sinkSpeed, 0);
    }
}
