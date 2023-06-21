using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //For Swipe Detection
    [SerializeField]
    private float minimumDistance = .2f;
    [SerializeField]
    private float maximumTime = 1f;
    [SerializeField, Range(0, 1)]
    private float directionThreshold = 0.9f;

    private InputManager inputManager;

    private Vector2 startPosition;
    private float startTime;
    private Vector2 endPosition;
    private float endTime;

    public float moveSpeed;
    public Rigidbody2D Rigidbody;


    public bool canMove =true;
    private Vector2 still = new Vector2(0, 0);

    private void Awake()
    {
        inputManager = InputManager.Instance;
    }

    private void OnEnable()
    {
        inputManager.OnStartTouch += SwipeStart;
        inputManager.OnEndTouch += SwipeEnd;
    }

    private void OnDisable()
    {
        inputManager.OnStartTouch -= SwipeStart;
        inputManager.OnEndTouch -= SwipeEnd;
    }

    private void SwipeStart(Vector2 position, float time)
    {
        startPosition = position;
        startTime = time;
    }

    private void SwipeEnd(Vector2 position, float time)
    {
        endPosition = position;
        endTime = time;
        DetectSwipe();
    }

    private void DetectSwipe()
    {
        if (Vector3.Distance(startPosition, endPosition) >= minimumDistance &&
            (endTime - startTime) <= maximumTime)
        {
            Debug.DrawLine(startPosition, endPosition, Color.green, 0.5f);
            Vector3 direction = endPosition - startPosition;
            Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
            SwipeDirection(direction2D);
        }
    }
    private void SwipeDirection(Vector2 direction)
    {
        //use dot product equation to determine direction of swipe.
        if (Vector2.Dot(Vector2.up, direction) > directionThreshold)
        {
            Debug.Log("SWIPED UP");
            Leap(new Vector2(0, moveSpeed));
        }
        else if (Vector2.Dot(Vector2.down, direction) > directionThreshold)
        {
            Debug.Log("SWIPED DOWN");
            Leap(new Vector2(0, -moveSpeed));
        }
        else if (Vector2.Dot(Vector2.right, direction) > directionThreshold)
        {
            Debug.Log("SWIPED RIGHT");
            Leap(new Vector2(moveSpeed, 0));
        }
        else if (Vector2.Dot(Vector2.left, direction) > directionThreshold)
        {
            Debug.Log("SWIPED LEFT");
            Leap(new Vector2(-moveSpeed, 0));
        }
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Hit wall");
        canMove = true;
    }

    private void Leap(Vector2 direction)
    {
        if (canMove == true)
        {
            if (Rigidbody.velocity != still)
            {
                canMove = false;
            }
            Rigidbody.velocity = still;
            Rigidbody.AddForce(direction);
        } 
    }
}
