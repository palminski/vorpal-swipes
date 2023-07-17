using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeBurst : MonoBehaviour
{
    private ParticleSystem ps;
    // Start is called before the first frame update
    void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!ps.isPlaying) {
            gameObject.SetActive(false);
        }
    }

    public void ColorBurst(Color colorToBurst) {

        var mainModule = ps.main;
        mainModule.startColor = colorToBurst;
        
        ps.Stop();
        ps.Clear();
        ps.Play();
    }
}
