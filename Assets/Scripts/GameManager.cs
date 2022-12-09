using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;

    public int health = -1;
    public float spawnRate = 1f;
    public bool active = false;
    

    // Start is called before the first frame update
    void Start()
    {
        titleScreen.SetActive(true);
        
        UpdateHealth(1);
    }

    // Update is called once per frame
    void Update()
    {
        //if (active) titleScreen.gameObject.SetActive(false);
    }

    IEnumerator SpawnTarget()
    {
        while (active)
        {
            yield return new WaitForSeconds(spawnRate);

            int index = Random.Range(0, targets.Count);

            Instantiate(targets[index]);
        }

    }

    public void UpdateHealth(int amount)
    {
        health += amount;
        healthText.text = "Heath: " + health;
    }

    public void GameOver()
    {
        active = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);

    }

    public void StartGame()
    {
        active = true;
        health = 0;
        StartCoroutine(SpawnTarget());
        titleScreen.gameObject.SetActive(false);

    }

    public void RestartGame()
    {
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}


