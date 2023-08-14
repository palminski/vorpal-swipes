using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField]
    [Range(-100, 0)]
    private float leftBound;
    [SerializeField]
    [Range(0, 100)]
    private float rightBound;
    [SerializeField]

    private float speed;
    private Rigidbody2D rigidBody;


    private float currentTarget;
    private float leftTarget;
    private float rightTarget;

    private bool still = false;

    public Animator animator;

    private Vector3 startingScale;
    // Start is called before the first frame update
    void Start()
    {
        animator  = GetComponent<Animator>();
        startingScale = transform.localScale;
        rigidBody = GetComponent<Rigidbody2D>();

        if (rightBound == 0 && leftBound == 0) still = true;

        leftTarget = gameObject.transform.position.x + leftBound;
        rightTarget = gameObject.transform.position.x + rightBound;

        currentTarget = rightTarget;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        transform.localScale = Vector3.Scale(startingScale, new Vector3(Mathf.Sign(rigidBody.velocity.x),1,1));

        if (!still)
        {
            //determine velocity based on current target x coord
            if (currentTarget == rightTarget)
            {
                rigidBody.velocity = new Vector2(speed, 0);
            }
            else
            {
                rigidBody.velocity = new Vector2(-speed, 0);
            }

            if (transform.position.x >= rightTarget && currentTarget == rightTarget)
            {
                if (HasTriggerParam("Turn")) animator.SetTrigger("Turn");
                currentTarget = leftTarget;
            }
            if (transform.position.x <= leftTarget && currentTarget == leftTarget)
            {
                currentTarget = rightTarget;
                if (HasTriggerParam("Turn")) animator.SetTrigger("Turn");
            }
        }

    }

    private bool HasTriggerParam(string paramName) {

        AnimatorControllerParameter[] parameters = animator.parameters;

        foreach(AnimatorControllerParameter parameter in parameters) {
            if (parameter.name == paramName && parameter.type == AnimatorControllerParameterType.Trigger) {
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
