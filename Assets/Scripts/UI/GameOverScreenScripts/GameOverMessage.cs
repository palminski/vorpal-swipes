using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverMessage : MonoBehaviour
{

    private TextMeshProUGUI gameOverMessage;
    private string gameOverString;
    private int i = 0;


    void Awake() {
        gameOverMessage = GetComponent<TextMeshProUGUI>();
        gameOverString = gameOverMessage.text;
    }
    // Start is called before the first frame update
    void Start()
    {
        gameOverMessage.text = "";
    }

    void FixedUpdate()
    {
        if (i < gameOverString.Length)
        {
            gameOverMessage.text += gameOverString[i];
            i++;
        }
    }
}
