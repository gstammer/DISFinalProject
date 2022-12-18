using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
 *  Control both Game Over and Pause screen 
 *
 */
public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false;
    public bool GameIsOver = false;
    public GameObject pauseMenuUI;
    public GameObject foodBar;
    public GameObject gameOverUI;

    //public AudioSource dieAudioSource;

    //public List<Button> buttons;
    //public GameObject mainCam, UICam;


    //private int btnIdx = 0;
    //private CursorLockMode gameCursor;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        var health = foodBar.GetComponent<FoodBar>().getHealth();
        if (health > 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !GameIsOver)
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
        if (health <= 0 && !GameIsOver)
        {
            Over();
        }

        if (!GameIsOver && !GameIsPaused)
        {
            Cursor.lockState = CursorLockMode.Locked;
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

    private void Over()
    {
        GameIsOver = true;
        pauseMenuUI.SetActive(false);
        gameOverUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;

        FindObjectOfType<AudioManager>().Play("deathSound");
        //dieAudioSource.Play();
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        //mainCam.SetActive(false);
        //UICam.SetActive(true);
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        //mainCam.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        GameIsOver = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        GameIsOver = false;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
