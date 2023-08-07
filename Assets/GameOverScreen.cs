using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class GameOverScreen : MonoBehaviour
{

    private PlayerInput playerInput;
    private InputAction tapAction;

    private TextMeshProUGUI gameOverText;
    [SerializeField]
    private TextMeshProUGUI gameOverMessage;


    private string gameOverString;
    private int i = 0;


    private Color colorForText = StaticVars.lastColor;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        gameOverText = GetComponent<TextMeshProUGUI>();
        gameOverString = gameOverText.text;
        tapAction = playerInput.actions.FindAction("Tap");
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

    private void OnEnable()
    {
        tapAction.performed += Tap;
    }

    private void OnDisable()
    {
        tapAction.performed -= Tap;
    }

    private void Tap(InputAction.CallbackContext context)
    {


        ControllerScript.Controller.LoadNextLevel("MainRoom");


    }
}
