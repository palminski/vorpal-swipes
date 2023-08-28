using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAfterImage : MonoBehaviour
{
    private Rigidbody2D rb;
    public int framesBetweenImage = 1;
    private int countdown;
    // Start is called before the first frame update
    void Start()
    {
        countdown = framesBetweenImage;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.velocity != new Vector2(0,0)) {
            if (countdown <= 0) {
                countdown = framesBetweenImage;
                PoolManager.PullFromPool("AfterImage",transform.position,transform.rotation, transform.localScale);
            }
            countdown --;
        }
    }
}
