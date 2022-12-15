using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    public List<Button> buttons;
    //public GameObject mainCam, UICam;


    private int btnIdx = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }

        /**
        if (GameIsPaused)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                btnIdx++;
                btnIdx = Math.Min(btnIdx, buttons.Count - 1);
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                btnIdx--;
                btnIdx = Math.Max(btnIdx, 0);
            }

            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                buttons[btnIdx].onClick.Invoke();
            }

            //Need to set button active
            buttons[btnIdx] ??
        }

        **/


    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        //mainCam.SetActive(false);
        //UICam.SetActive(true);
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        //mainCam.SetActive(true);
    }
}
