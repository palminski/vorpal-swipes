using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodScript : MonoBehaviour
{
    private ParticleSystem ps;

    [SerializeField]
    private Color defaultBloodColor;
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

        var mainModule = ps.main;
        mainModule.startColor = defaultBloodColor;

        ps.Stop();
        ps.Clear();
        ps.Play();
    }
    public void Splatter(Color colorOfBlood) {

        var mainModule = ps.main;
        mainModule.startColor = colorOfBlood;

        ps.Stop();
        ps.Clear();
        ps.Play();
    }
}
