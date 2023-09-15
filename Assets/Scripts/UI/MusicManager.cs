using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance = null;
    public static MusicManager Instance { get { return instance; } }

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        }
        else {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);


        audioSource = GetComponent<AudioSource>();
        
        if (PlayerPrefs.GetInt("allowMusic", 1) == 0) {
            StopMusic();
        }
    }

    public void StopMusic() {
        audioSource.Stop();
    }

    public void StartMusic() {
        audioSource.Play();
    }
}
