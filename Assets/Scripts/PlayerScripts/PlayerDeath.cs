using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerDeath : MonoBehaviour
{

    public Light2D playerLight;
    public void KillPlayer() {

        if (playerLight) Instantiate(playerLight, transform.position, transform.rotation);
        
        
        GameObject blood = PoolManager.PullWithoutRotation("Blood", transform.position);
        
        if (blood) blood.GetComponent<BloodScript>().Splatter();

        transform.position = new Vector3 (1000,0,0);
    }
}
