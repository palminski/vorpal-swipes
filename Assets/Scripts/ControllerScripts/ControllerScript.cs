using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerScript : MonoBehaviour
{

    public static ControllerScript Controller {get; private set;}

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
        Controller = this;
        Score = 0;
        SinkSpeed = 0;
    }

        private void FixedUpdate()
    {
        if (SinkSpeed < maxSinkSpeed)
        {
            //for now it will not scroll until the sink speed is initially set
           if (SinkSpeed != 0) UpdateSinkSpeed(sinkSpeedIncrease);
        }
        else
        {
            SinkSpeed = maxSinkSpeed;
        }
        
    }

    public void GameOver() {
        UpdateHighScores(Score);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void IncreaseScore(int points) {
        Score += points;
    }

    public void UpdateSinkSpeed(float speedToAdd)
    {
        SinkSpeed += speedToAdd;
    }
    public void StartSinking()
    {
        SinkSpeed = startingSinkSpeed;
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


