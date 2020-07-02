using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource source;

    public AudioClip song1;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        source.clip = song1;
        source.volume = 0.8f;
        source.Play();
    }
}
