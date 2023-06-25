
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction swipeAction;

    //For Swipe Detection
    [SerializeField]
    private float swipeSensitivity = .2f;
    [SerializeField, Range(0, 1)]
    private float directionThreshold = 0.9f;

    //For Movement
    public float jumpForce;
    public Rigidbody2D Rigidbody;

    private Vector2 still = new Vector2(0, 0);
    //===================================================================
    #region INPUT DETECTION
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        swipeAction = playerInput.actions.FindAction("Swipe");
    }

    private void OnEnable()
    {
        swipeAction.performed += Swipe;
    }

    private void OnDisable()
    {
        swipeAction.performed -= Swipe;
    }

    private void Swipe( InputAction.CallbackContext context)
    {
        Vector2 swipeVector = context.ReadValue<Vector2>();

        if (swipeVector.magnitude >= swipeSensitivity)
        {
            Vector2 swipeDirection = swipeVector.normalized;

            if (Vector2.Dot(Vector2.up, swipeDirection) > directionThreshold)
            {
                Leap(new Vector2(0, jumpForce));
            }
            else if (Vector2.Dot(Vector2.down, swipeDirection) > directionThreshold)
            {
                Leap(new Vector2(0, -jumpForce));
            }
            else if (Vector2.Dot(Vector2.right, swipeDirection) > directionThreshold)
            {
                Leap(new Vector2(jumpForce,0));
            }
            else if (Vector2.Dot(Vector2.left, swipeDirection) > directionThreshold)
            {
                Leap(new Vector2(-jumpForce,0));
            }
        }
    }

    #endregion
    //===================================================================

    private void OnCollisionStay2D(Collision2D collision)
    {
        //
    }

    private void Leap(Vector2 direction)
    {
        Debug.Log(direction);
        Rigidbody.velocity = direction;
    }
}
