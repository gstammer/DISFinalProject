using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    
    public Sound[] sounds;
    // Start is called before the first frame update

    void Awake()
    {
        foreach(var sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

        }
    }

    public void Play(string name)
    {
        Array.Find<Sound>(sounds, s => s.audioName == name).source.Play();
    }
}
