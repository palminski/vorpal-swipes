using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ReReverse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (transform.lossyScale.x == -1) {
            Vector3 localScale = transform.localScale;
            transform.localScale = new Vector3(-localScale.x,localScale.y,localScale.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
