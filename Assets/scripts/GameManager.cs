using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject gamePausePanel;

    public int score = 0;
    public int highScore = 0;

    private bool isPaused = false;

    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        scoreText.text = "Score: " + score.ToString();
    }

    [ContextMenu("AddScore")]
    public void AddScore()
    {
        score++;
        if (score > highScore)
        {
            highScore = score;
        }
    }

    public void RestartGame()
    {
        score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void PauseGame()
    {
        isPaused = !isPaused;
        gamePausePanel.SetActive(isPaused);
        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("main");
    }
}
