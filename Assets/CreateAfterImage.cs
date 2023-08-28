using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAfterImage : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.velocity != new Vector2(0,0)) {
            PoolManager.PullFromPool("AfterImage",transform.position,transform.rotation, transform.localScale);
        }
    }
}
