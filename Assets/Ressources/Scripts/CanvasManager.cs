using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    private bool isPause = false;
    public GameObject pauseBtn;
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public GameObject coinPanelText;
    public GameObject coinPanel;
    public GameObject gameOverCoinText;
    public GameObject gameOverScoreText;
    public GameObject scorePanel;
    public GameObject highScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PausePlay()
    {
        if (isPause)
        {
            isPause = false;
            Time.timeScale = 1;
            pauseBtn.SetActive(true);
            pausePanel.SetActive(false);
        }
        else
        {
            isPause = true;
            Time.timeScale = 0;
            pauseBtn.SetActive(false);
            pausePanel.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        coinPanelText.GetComponent<CoinAmount>().SaveCoin();
        gameOverCoinText.GetComponent<Text>().text = PlayerPrefs.GetInt("CoinAmount").ToString();
        gameOverScoreText.GetComponent<Text>().text = scorePanel.transform.Find("ScoreText").GetComponent<Text>().text;
        if ( int.Parse(gameOverScoreText.GetComponent<Text>().text) > PlayerPrefs.GetInt("HighScore") )
        {
            highScore.SetActive(true);
            PlayerPrefs.SetInt("HighScore", int.Parse(gameOverScoreText.GetComponent<Text>().text));
        }
        gameOverPanel.SetActive(true);
        coinPanel.SetActive(false);
        scorePanel.SetActive(false);
        pauseBtn.SetActive(false);
    }
}
