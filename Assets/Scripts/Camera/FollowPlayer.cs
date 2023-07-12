using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform player;
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(player.position.x,-1000,0) ,player.position.y  ,-10);
       
    }
}
