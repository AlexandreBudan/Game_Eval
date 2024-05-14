using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinAmount : MonoBehaviour
{
    private TextMeshProUGUI coinText;
    // Start is called before the first frame update
    void Start()
    {
        coinText = gameObject.GetComponent<TextMeshProUGUI>();
        coinText.text = PlayerPrefs.GetInt("CoinAmount", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Trésor Sauvegardé");
            PlayerPrefs.SetInt("CoinAmount", int.Parse(coinText.text));
        }
    }
}
