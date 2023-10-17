using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAfterImage : MonoBehaviour
{
    private Animator animator;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (animator.GetBool("Moving")) {
            
                PoolManager.PullFromPool("AfterImage",transform.position,transform.rotation, transform.localScale);
            
            
        }
        
    }
}
