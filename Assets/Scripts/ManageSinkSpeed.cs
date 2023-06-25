using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageSinkSpeed : MonoBehaviour
{
    [SerializeField, Range(0, 0.1f)]
    private float sinkSpeedIncrease;
    [SerializeField, Range(0, 0.5f)]
    private float maxSinkSpeed;
    private void FixedUpdate()
    {
        if (GlobalVariables.sinkSpeed < maxSinkSpeed)
        {
            GlobalVariables.sinkSpeed += sinkSpeedIncrease;
        }
        else
        {
            GlobalVariables.sinkSpeed = maxSinkSpeed;
        }
        
    }
}
