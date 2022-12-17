using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDoorSound : MonoBehaviour
{
    public AudioSource source;
    // Start is called before the first frame update

    public void Play() => source.Play();
}
