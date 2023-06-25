using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public float startingSinkSpeed = 0.5f;

    public static float sinkSpeed;

    private void Awake()
    {
        GlobalVariables.sinkSpeed = startingSinkSpeed;
    }
}


