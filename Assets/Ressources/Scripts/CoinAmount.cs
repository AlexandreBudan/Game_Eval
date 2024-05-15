using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinAmount : MonoBehaviour
{
    private Text coinText;
    // Start is called before the first frame update
    void Start()
    {
        coinText = gameObject.GetComponent<Text>();
        coinText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SaveCoin()
    {
        int coinAlreadyCollected = PlayerPrefs.GetInt("CoinAmount");
        PlayerPrefs.SetInt("CoinAmount", coinAlreadyCollected + int.Parse(coinText.text));
    }
}
