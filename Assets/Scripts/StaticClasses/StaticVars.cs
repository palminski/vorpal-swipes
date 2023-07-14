using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticVars
{
    public static float lastScore = 0;

    public static void UpdateLastScore(float newScore) {
        lastScore = newScore;
    }
}


