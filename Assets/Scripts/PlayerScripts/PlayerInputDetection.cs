
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputDetection : MonoBehaviour
{

    //Input Detection
    private PlayerInput playerInput;
    private InputAction swipeAction;
    private InputAction tapAction;

    //For Swipe Sensitivity
    [SerializeField]
    private float swipeSensitivity = .2f;
    [SerializeField, Range(0, 1)]
    private float directionThreshold = 0.9f;


    //Scripts to Communicate With
    private PlayerMovement playerMovement;
    private PlayerColorChange playerColorChange;


private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerMovement = GetComponent<PlayerMovement>();
        playerColorChange = GetComponent<PlayerColorChange>();

        swipeAction = playerInput.actions.FindAction("Swipe");
        tapAction = playerInput.actions.FindAction("Tap");

    }

    private void OnEnable()
    {
        swipeAction.performed += Swipe;
        tapAction.performed += Tap;
    }

    private void OnDisable()
    {
        swipeAction.performed -= Swipe;
        tapAction.performed -= Tap;
    }

    private void Swipe( InputAction.CallbackContext context)
    {
        Vector2 swipeVector = context.ReadValue<Vector2>();

        

        if (swipeVector.magnitude >= swipeSensitivity && ControllerScript.Controller.SinkSpeed != 0)
        {
            Vector2 swipeDirection = swipeVector.normalized;

            if (Vector2.Dot(Vector2.up, swipeDirection) > directionThreshold)
            {
                playerMovement.Leap(new Vector2(0, 1));
            }
            else if (Vector2.Dot(Vector2.down, swipeDirection) > directionThreshold)
            {
                playerMovement.Leap(new Vector2(0, -1));
            }
            else if (Vector2.Dot(Vector2.right, swipeDirection) > directionThreshold)
            {
                playerMovement.Leap(new Vector2(1,0));
            }
            else if (Vector2.Dot(Vector2.left, swipeDirection) > directionThreshold)
            {
                playerMovement.Leap(new Vector2(-1,0));
            }
        }

    }

    private void Tap(InputAction.CallbackContext context) {
        playerColorChange.SwapColor();
        Debug.Log(context.ReadValueAsObject());
        
    }
}
