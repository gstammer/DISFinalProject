using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    [Tooltip("Files -> Build Settings -> Add Scene -> Copy & Paste scene's name here")]
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    public void OpenScene()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(sceneName);
    }
    
}
