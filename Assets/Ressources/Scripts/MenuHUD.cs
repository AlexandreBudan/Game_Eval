using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuHUD : MonoBehaviour
{
    public GameObject CoinPanel;
    public GameObject HighScorePanel;
    public GameObject confPanel;
    private bool isConf = false;
    // Start is called before the first frame update
    void Start()
    {
        CoinPanel.GetComponent<Text>().text = PlayerPrefs.GetInt("CoinAmount").ToString();
        HighScorePanel.GetComponent<Text>().text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {

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
}
