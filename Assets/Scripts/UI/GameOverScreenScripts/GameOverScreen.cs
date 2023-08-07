using UnityEngine;

using TMPro;


public class GameOverScreen : MonoBehaviour
{

    

    private TextMeshProUGUI gameOverText;
    [SerializeField]
    private TextMeshProUGUI gameOverMessage;


    private string gameOverString;
    private int i = 0;


    private Color colorForText = StaticVars.lastColor;

    // Start is called before the first frame update
    void Awake()
    {
        
        gameOverText = GetComponent<TextMeshProUGUI>();
        gameOverString = gameOverText.text;
        
        // ColorUtility.TryParseHtmlString("#" + PlayerPrefs.GetString("colorA", "07FF00"), out colorForText);
    }

    void Start()
    {
        gameOverText.color = colorForText;
        gameOverMessage.color = colorForText;

        gameOverText.text = "";
    }

    void FixedUpdate()
    {
        if (i < gameOverString.Length)
        {
            gameOverText.text += gameOverString[i];
            i++;
        }
    }

}
