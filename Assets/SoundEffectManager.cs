using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void playEffect(AudioClip audioClip) {
        Debug.Log("Running");
        audioSource.PlayOneShot(audioClip);
    }
}
