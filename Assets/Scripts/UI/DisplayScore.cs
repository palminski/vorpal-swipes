using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayScore : MonoBehaviour
{

    

    private TextMeshProUGUI scoreText;

    private SpriteRenderer playerSpriteRenderer;

    private void OnEnable() {
        PlayerColorChange.OnColorChange += SwapColor;
    }

    private void OnDisable() {
        PlayerColorChange.OnColorChange -= SwapColor;
    }
    
    void SwapColor() {
        scoreText.color = playerSpriteRenderer.color;
    }

    void Start() {
        scoreText = GetComponent<TextMeshProUGUI>();
        playerSpriteRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        SwapColor();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: "+ ControllerScript.Controller.Score;
    }


}
