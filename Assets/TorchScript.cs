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
    // Start is called before the first frame update
    void Start()
    {
        
        mainModule = GetComponentInChildren<ParticleSystem>().main;
        spriteRenderer = GetComponent<SpriteRenderer>();
        torchLight = GetComponentInChildren<Light2D>();
        playerSpriteRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        torchLight.color = playerSpriteRenderer.color;
        mainModule.startColor = playerSpriteRenderer.color;
        spriteRenderer.color = playerSpriteRenderer.color;
    }
}
