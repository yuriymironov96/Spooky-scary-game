using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI timer;
    public Canvas gameOverCanvas;

    public float timeRemaining = 60;

    // Start is called before the first frame update
    void Start()
    {
        gameOverCanvas.gameObject.SetActive(false);
        UpdateTime(timeRemaining);
    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            UpdateTime(0);
            Victory();
        }
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTime(timeRemaining);
        }
        else
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0) {
                UpdateTime(0);
                GameOver();
            }
        }
    }

    void UpdateTime(float timeLeft)
    {
        timer.SetText("Time left: " + timeLeft.ToString("0"));
    }

    void GameOver()
    {
        gameOverText.SetText("GAME OVER");
        gameOverCanvas.gameObject.SetActive(true);
    }

    void Victory()
    {
        gameOverText.SetText("SPOOOOKY");
        gameOverCanvas.gameObject.SetActive(true);
    }

    public void OnRetryButton ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnMenuButton ()
    {
        SceneManager.LoadScene(0);
    }
}
