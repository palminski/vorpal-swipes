using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageSinkSpeed : MonoBehaviour
{
    [SerializeField]
    private float startingSinkSpeed = 0.5f;
    [SerializeField, Range(0, 0.1f)]
    private float sinkSpeedIncrease;
    [SerializeField, Range(0, 0.5f)]
    private float maxSinkSpeed;

    

    public float sinkSpeed;

    private void Awake()
    {
        sinkSpeed = startingSinkSpeed;
    }

    private void FixedUpdate()
    {
        if (sinkSpeed < maxSinkSpeed)
        {
            UpdateSinkSpeed(sinkSpeedIncrease);
        }
        else
        {
            sinkSpeed = maxSinkSpeed;
        }
        
    }

    public void UpdateSinkSpeed(float speedToAdd)
    {
        sinkSpeed += speedToAdd;
    }
}
