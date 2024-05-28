using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int baseScorePoint = 1;
    public int muliplier = 1;
    private int currentScore = 0;
    private int highScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        highScore = PlayerPrefs.GetInt("HighScore");
        StartCoroutine("Scoring");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        currentScore += scoreToAdd * muliplier;
        gameObject.GetComponent<Text>().text = currentScore.ToString();
        if (currentScore / 250.0f == (int)Math.Floor(currentScore / 250.0f))
        {
            PlayerPrefs.SetInt("Score", 250 *  (int)Math.Floor(currentScore / 250.0f));
        }
    }

    private IEnumerator Scoring()
    {
        while (true)
        {
            UpdateScore(baseScorePoint);
            if (currentScore > highScore)
            {
                gameObject.GetComponent<Text>().color = Color.yellow;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
