
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class TextScroll : MonoBehaviour
{

    private PlayerInput playerInput;
    private InputAction tapAction;

    [SerializeField]
    private float scrollDelay = 100;


    
    //======================================================
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


    void FixedUpdate() {
        if (scrollDelay > 0) {
                    scrollDelay--;
        }
        if (scrollDelay == 1) {
            ControllerScript.Controller.StartGame();
        }

    }

    private void Tap(InputAction.CallbackContext context) {


            ControllerScript.Controller.LoadNextLevel("MainRoom");


    }
}
