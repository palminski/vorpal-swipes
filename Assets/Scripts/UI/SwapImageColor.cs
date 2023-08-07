
using UnityEngine;
using UnityEngine.UI;

public class SwapImageColor : MonoBehaviour
{
    private Image thisImage;
    
    private SpriteRenderer playerSpriteRenderer;

    private void OnEnable() {
        PlayerColorChange.OnColorChange += SwapColor;
    }

    private void OnDisable() {
        PlayerColorChange.OnColorChange -= SwapColor;
    }
    
    void SwapColor() {
        thisImage.color = playerSpriteRenderer.color;
    }

    void Start() {
        thisImage = GetComponent<Image>();
        playerSpriteRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        SwapColor();
    }
}
