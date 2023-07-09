using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{

    public static GlobalVariables Variables {get; private set;}

    [SerializeField]
    private float startingSinkSpeed = 0.5f;
    [SerializeField, Range(0, 0.1f)]
    private float sinkSpeedIncrease;
    [SerializeField, Range(0, 0.5f)]
    private float maxSinkSpeed;

    public int Score {get; private set;}
    public float SinkSpeed {get; private set;}



    private void Awake()
    {
        Variables = this;
        Score = 0;
        SinkSpeed = startingSinkSpeed;
    }

        private void FixedUpdate()
    {
        if (SinkSpeed < maxSinkSpeed)
        {
            UpdateSinkSpeed(sinkSpeedIncrease);
        }
        else
        {
            SinkSpeed = maxSinkSpeed;
        }
        
    }

    public void IncreaseScore(int points) {
        Score += points;
    }

    public void UpdateSinkSpeed(float speedToAdd)
    {
        SinkSpeed += speedToAdd;
    }

    public void UpdateHighScores(int newScore) {
        int[] highScoreArray = System.Array.ConvertAll(PlayerPrefs.GetString("highScores","1000###1000###1000###1000###1000").Split("###"), int.Parse);

        if (highScoreArray[0] < newScore) {
            highScoreArray[0] = newScore;
            System.Array.Sort(highScoreArray);
            PlayerPrefs.SetString("highScores", string.Join("###",highScoreArray));
        }
    }
}


