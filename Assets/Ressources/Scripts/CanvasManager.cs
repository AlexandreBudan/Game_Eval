using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    private bool isPause = false;
    private bool isConf = false;
    public GameObject pauseBtn;
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public GameObject coinPanelText;
    public GameObject coinPanel;
    public GameObject gameOverCoinText;
    public GameObject gameOverScoreText;
    public GameObject scorePanel;
    public GameObject confPanel;
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
            GameObject.Find("Music").GetComponent<AudioSource>().Play();
            isPause = false;
            Time.timeScale = 1;
            pauseBtn.SetActive(true);
            pausePanel.SetActive(false);
        }
        else
        {
            GameObject.Find("Music").GetComponent<AudioSource>().Pause();
            isPause = true;
            Time.timeScale = 0;
            pauseBtn.SetActive(false);
            pausePanel.SetActive(true);
        }
    }

    public void ConfigDisplay()
    {
        if (isConf)
        {
            isConf = false;
            confPanel.SetActive(false);
        }
        else
        {
            isConf = true;
            confPanel.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        GameObject.Find("LoseSound").GetComponent<AudioSource>().Play(0);
        GameObject.Find("Music").GetComponent<AudioSource>().Stop();
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
