using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PauseScreen : MonoBehaviour
{

    
    private SpriteRenderer playerSpriteRenderer;
    private TextMeshProUGUI pauseText;
    // Start is called before the first frame update
    void Start()
    {
        pauseText = GetComponentInChildren<TextMeshProUGUI>();
        playerSpriteRenderer = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.timeScale != 0) {
            gameObject.SetActive(false);
        }
    }

    void OnEnable() {
        pauseText.color = playerSpriteRenderer.color;
    }

}
