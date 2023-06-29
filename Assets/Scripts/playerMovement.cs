
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction swipeAction;
    private InputAction tapAction;

    //For Swipe Detection
    [SerializeField]
    private float swipeSensitivity = .2f;
    [SerializeField, Range(0, 1)]
    private float directionThreshold = 0.9f;

    //For Movement
    public float jumpForce;
    public Rigidbody2D Rigidbody;

    //For Sprite
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private Vector2 still = new Vector2(0, 0);
    //===================================================================
    #region INPUT DETECTION
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        swipeAction = playerInput.actions.FindAction("Swipe");
        tapAction = playerInput.actions.FindAction("Tap");

        // For testing as of now
        spriteRenderer.color = Color.green;
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

    private void Tap(InputAction.CallbackContext context) {
        if (spriteRenderer.color == Color.green) {
            spriteRenderer.color = Color.magenta;
        } 
        else {
            spriteRenderer.color = Color.green;
        }
    }

    #endregion
    //===================================================================

    private void FixedUpdate()
    {
        //
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //
    }

    private void Leap(Vector2 direction)
    {
        Rigidbody.velocity = direction;
    }
}
