using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    private static SoundOnLoad instance = null;
    public static SoundOnLoad Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
