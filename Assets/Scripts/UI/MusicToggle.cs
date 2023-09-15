using UnityEngine;
using UnityEngine.UI;

public class MusicToggle : MonoBehaviour
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

        bool allowMusic = PlayerPrefs.GetInt("allowMusic", 1) != 0;

        if (allowMusic)
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

        bool allowMusic = PlayerPrefs.GetInt("allowMusic", 1) != 0;

        if (allowMusic)
        {
            thisImage.sprite = onSprite; 
        }
        else
        {
            thisImage.sprite = offSprite;  
        }
    }

    public void ToggleMusic()
    {
        bool allowMusic = PlayerPrefs.GetInt("allowMusic", 1) != 0;

        if (allowMusic)
        {
            PlayerPrefs.SetInt("allowMusic", 0);
            MusicManager.Instance.StopMusic();
            thisImage.sprite = offSprite; 
        }
        else
        {
            PlayerPrefs.SetInt("allowMusic", 1);
            MusicManager.Instance.StartMusic();
            thisImage.sprite = onSprite;
            
        }
    }
}
