using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodScript : MonoBehaviour
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

    public void Splatter() {
        ps.Stop();
        ps.Clear();
        ps.Play();
    }
}
