using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAfterImage : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    [Range(0,1)]public float newImageTime = 1;
    private float countdown;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        countdown = 1;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (animator.GetBool("Moving")) {
            if (countdown <= 0) {
                countdown = 1;
                PoolManager.PullFromPool("AfterImage",transform.position,transform.rotation, transform.localScale);
            }
            countdown -= newImageTime;
        }
        
    }
}
