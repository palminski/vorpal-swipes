using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField]
    private GameObject pointA;
    [SerializeField]
    private GameObject pointB;
    [SerializeField]
    private float speed;

    private Rigidbody2D rigidBody;
    private Transform currentPoint;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (currentPoint == pointB.transform)
        {
            rigidBody.velocity = new Vector2(speed, 0);
        }
        else
        {
            rigidBody.velocity = new Vector2(-speed, 0);
        }

        if (transform.position.x >= currentPoint.position.x && currentPoint == pointB.transform) {
            currentPoint = pointA.transform;
        }
        if (transform.position.x <= currentPoint.position.x && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}
