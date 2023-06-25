using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{
    public float sinkSpeed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        sinkSpeed = 0.0f;
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
