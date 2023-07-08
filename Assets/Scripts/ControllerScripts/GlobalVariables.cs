using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{

    public static GlobalVariables Variables {get; private set;}

    public float Score {get; private set;}

    private void Awake()
    {
        Variables = this;
        Score = 0;
    }

    public void IncreaseScore(float points) {
        Score += points;
    }
}


