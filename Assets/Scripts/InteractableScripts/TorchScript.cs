using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class TorchScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private SpriteRenderer playerSpriteRenderer;
    private ParticleSystem.MainModule mainModule;

    private Light2D torchLight;

    private void OnEnable() {
        PlayerColorChange.OnColorChange += SwapColor;
    }

    private void OnDisable() {
        PlayerColorChange.OnColorChange -= SwapColor;
    }


    // Start is called before the first frame update
    void Start()
    {
        
        mainModule = GetComponentInChildren<ParticleSystem>().main;
        spriteRenderer = GetComponent<SpriteRenderer>();
        torchLight = GetComponentInChildren<Light2D>();
        playerSpriteRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        SwapColor();

    }

    // Update is called once per frame
    void SwapColor()
    {
        torchLight.color = playerSpriteRenderer.color;
        mainModule.startColor = playerSpriteRenderer.color;
        spriteRenderer.color = playerSpriteRenderer.color;
    }
}
