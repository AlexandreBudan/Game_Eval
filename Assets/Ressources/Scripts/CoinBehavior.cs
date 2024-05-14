using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsBehavior : MonoBehaviour
{
    public int value = 1;
    private TextMeshProUGUI coinText;
    private GameObject UI;

    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.FindGameObjectWithTag("CoinAmount");
        coinText = UI.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            int currentAmount = int.Parse(coinText.text) + value;
            coinText.text = currentAmount.ToString();
            Destroy(gameObject);
        }
    }
}
