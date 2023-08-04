using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class GameOverScreen : MonoBehaviour
{

    private PlayerInput playerInput;
    private InputAction tapAction;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        tapAction = playerInput.actions.FindAction("Tap");
    }

    private void OnEnable()
    {
        tapAction.performed += Tap;
    }

    private void OnDisable()
    {
        
        tapAction.performed -= Tap;
    }

        private void Tap(InputAction.CallbackContext context) {


            SceneManager.LoadScene("MainRoom");


    }
}
