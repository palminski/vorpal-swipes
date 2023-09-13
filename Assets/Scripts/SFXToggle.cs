using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXToggle : MonoBehaviour
{

    private Image thisImage;

    [SerializeField]
    private Sprite onSprite;

    [SerializeField]
    private Sprite offSprite;

    // Start is called before the first frame update
    void Start()
    {

        thisImage = GetComponent<Image>();

        bool allowSFX = PlayerPrefs.GetInt("allowSFX", 1) != 0;

        if (allowSFX)
        {
            thisImage.sprite = onSprite; 
        }
        else
        {
            thisImage.sprite = offSprite;  
        }
    }

    void OnEnable() {

        if (!thisImage) return;

        bool allowSFX = PlayerPrefs.GetInt("allowSFX", 1) != 0;

        if (allowSFX)
        {
            thisImage.sprite = onSprite; 
        }
        else
        {
            thisImage.sprite = offSprite;  
        }
    }

    public void ToggleSFX()
    {
        bool allowSFX = PlayerPrefs.GetInt("allowSFX", 1) != 0;

        if (allowSFX)
        {
            PlayerPrefs.SetInt("allowSFX", 0);
            thisImage.sprite = offSprite; 
        }
        else
        {
            PlayerPrefs.SetInt("allowSFX", 1);
            thisImage.sprite = onSprite;
            
        }
    }
}
