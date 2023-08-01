
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class TextScroll : MonoBehaviour
{

    private PlayerInput playerInput;
    private InputAction tapAction;

    [SerializeField]
    private float scrollSpeed = 0.05f;

    [SerializeField]
    private int startingMoveDelay = 100;

    private int moveDelay;
    

    private Vector3 startingPosition;
    
    //======================================================
    void Awake()
    {
        startingPosition = transform.position;
        moveDelay = startingMoveDelay;
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

    private void resetPosition() {
        moveDelay = startingMoveDelay;
        transform.position = startingPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveDelay > 0) moveDelay--;
        if (moveDelay <= 0) transform.position += new Vector3(0, scrollSpeed, 0);
    }

    private void Tap(InputAction.CallbackContext context) {

        if (moveDelay > 0 ) {
            ControllerScript.Controller.LoadNextLevel("MainRoom");
        }
        else {
            resetPosition();
        }
    }
}
