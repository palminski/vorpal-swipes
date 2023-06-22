using System.Collections;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{


    [SerializeField]
    private float minimumDistance = .2f;
    [SerializeField]
    private float maximumTime = 1f;
    [SerializeField, Range(0,1)]
    private float directionThreshold = 0.9f;

    private InputManager inputManager;

    private Vector2 startPosition;
    private float startTime;
    private Vector2 endPosition;
    private float endTime;

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
        //for swipe
        if (Vector3.Distance(startPosition, endPosition) >= minimumDistance &&
            (endTime-startTime) <= maximumTime)
        {
            Debug.DrawLine(startPosition, endPosition, Color.green,0.5f);
            Vector3 direction = endPosition - startPosition;
            Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
            SwipeDirection(direction2D);
        }
        else
        {
            Debug.Log("TAPPED");
        }
    }
    private void SwipeDirection(Vector2 direction)
    {
        //use dot product equation to determine direction of swipe.
        if (Vector2.Dot(Vector2.up, direction) > directionThreshold)
        {
            Debug.Log("SWIPED UP");
        }
        else if (Vector2.Dot(Vector2.down, direction) > directionThreshold)
        {
            Debug.Log("SWIPED DOWN");
        }
        else if (Vector2.Dot(Vector2.right, direction) > directionThreshold)
        {
            Debug.Log("SWIPED RIGHT");
        }
        else if (Vector2.Dot(Vector2.left, direction) > directionThreshold)
        {
            Debug.Log("SWIPED LEFT");
        }
    }
}
