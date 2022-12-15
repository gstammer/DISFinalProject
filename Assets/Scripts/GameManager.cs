using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int sceneNum;
    public GameObject UIGameOver;



    void Awake()
    {
        MakeSingleton();
    }

    // Start is called before the first frame update
    void Start()
    {
        sceneNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if (active) titleScreen.gameObject.SetActive(false);
    }

    private void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }

    }

    public void restartScene() {
        SceneManager.LoadScene(sceneNum);
    }
    public void nextScene() {
        sceneNum++;
        if (sceneNum > 1) {
            sceneNum = 0;
        }
        SceneManager.LoadScene(sceneNum);

    }
}


