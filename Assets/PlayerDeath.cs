using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerDeath : MonoBehaviour
{

    public Light2D playerLight;
    public void KillPlayer() {

        if (playerLight) Instantiate(playerLight, transform.position, transform.rotation);
        gameObject.SetActive(false);
        
        GameObject blood = PoolManager.PullWithoutRotation("Blood", transform.position);
        blood.GetComponent<BloodScript>().Splatter();
    }
}
