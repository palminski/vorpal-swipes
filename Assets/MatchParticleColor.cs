using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchParticleColor : MonoBehaviour
{
    private ParticleSystem.MainModule mainModule;
    
    // Start is called before the first frame update
    void Start()
    {
        
        mainModule = GetComponent<ParticleSystem>().main;
        
    }

    // Update is called once per frame
    public void setColor(Color color)
    {
        mainModule.startColor = color;
    }
}
