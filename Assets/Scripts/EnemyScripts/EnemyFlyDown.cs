using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyDown : MonoBehaviour
{
    [SerializeField]
    [Range(-100, 0)]
    private float leftBound;
    [SerializeField]
    [Range(0, 100)]
    private float rightBound;
    [SerializeField]
    private float vSpeed = 0.01f;
    [SerializeField]
    private float hSpeed = 1;

    [SerializeField]
    private float easeAmount;

    private Rigidbody2D rigidBody;

    private float leftTarget;
    private float rightTarget;





    private Animator animator;

    private Vector3 startingScale;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        startingScale = transform.lossyScale;
        rigidBody = GetComponent<Rigidbody2D>();


        leftTarget = gameObject.transform.position.x + leftBound;
        rightTarget = gameObject.transform.position.x + rightBound;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float preUpdatedXVelocity = rigidBody.velocity.x;
        transform.localScale = Vector3.Scale(startingScale, new Vector3(Mathf.Sign(rigidBody.velocity.x), 1, 1));

        float easedX = Mathf.SmoothStep(leftTarget, rightTarget, Mathf.PingPong(Time.time * easeAmount, 1));
        Vector2 targetPosition = new Vector2(easedX, transform.position.y);
        Vector2 velocity = hSpeed * (targetPosition - rigidBody.position) / Time.fixedDeltaTime;
        if (ControllerScript.Controller.SinkSpeed != 0) rigidBody.velocity = new Vector2(velocity.x, -vSpeed);
        

        //turn if velocity swapped
        if (Mathf.Sign(preUpdatedXVelocity) != Mathf.Sign(rigidBody.velocity.x) && HasTriggerParam("Turn")) animator.SetTrigger("Turn");

        //Y should always decrease by set ammount
        // transform.position -= new Vector3(0,vSpeed,0);

    }

    private bool HasTriggerParam(string paramName)
    {

        AnimatorControllerParameter[] parameters = animator.parameters;

        foreach (AnimatorControllerParameter parameter in parameters)
        {
            if (parameter.name == paramName && parameter.type == AnimatorControllerParameterType.Trigger)
            {
                return true;
            }
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(new Vector3(gameObject.transform.position.x + leftBound, gameObject.transform.position.y, 0), 0.5f);
        Gizmos.DrawWireSphere(new Vector3(gameObject.transform.position.x + rightBound, gameObject.transform.position.y, 0), 0.5f);
        Gizmos.DrawLine(new Vector3(gameObject.transform.position.x + leftBound, gameObject.transform.position.y, 0), new Vector3(gameObject.transform.position.x + rightBound, gameObject.transform.position.y, 0));
    }
}
