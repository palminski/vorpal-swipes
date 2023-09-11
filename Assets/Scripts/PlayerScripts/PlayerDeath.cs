using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerDeath : MonoBehaviour
{

    public Light2D playerLight;
    public bool playerDead = false;

    private SpriteRenderer sr;

    public void Start() {
        sr = GetComponent<SpriteRenderer>();
        playerDead = false;
    }
    public void KillPlayer() {

        playerDead = true;
        if (playerLight) Instantiate(playerLight, transform.position, transform.rotation);
        
        
        GameObject blood = PoolManager.PullWithoutRotation("Blood", transform.position);
        
        if (blood) blood.GetComponent<BloodScript>().Splatter(sr.color);

        transform.position = new Vector3 (1000,0,0);
    }
}
