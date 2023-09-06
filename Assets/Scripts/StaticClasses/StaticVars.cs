using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticVars
{
    public static float lastScore = 0;

    public static string entryPosition = "center";

    public static Color lastColor;

    

    public static void UpdateLastScore(float newScore) {
        lastScore = newScore;
    }

    public static void setEntryPosition(string newEntryPosition) {
        entryPosition = newEntryPosition;
    }

    public static void SetLastColor(Color newColor) {
        lastColor = newColor;
    }

    


}


