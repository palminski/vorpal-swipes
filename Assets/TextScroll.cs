
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class TextScroll : MonoBehaviour
{

    private PlayerInput playerInput;
    private InputAction tapAction;

    


    
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




    private void Tap(InputAction.CallbackContext context) {


            ControllerScript.Controller.LoadNextLevel("MainRoom");


    }
}
