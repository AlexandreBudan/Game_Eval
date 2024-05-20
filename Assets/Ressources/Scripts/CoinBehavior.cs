using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsBehavior : MonoBehaviour
{
    public int value = 0;
    private Text coinText;
    private GameObject UI;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.FindGameObjectWithTag("CoinAmount");
        coinText = UI.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            GameObject.Find("CoinSound").GetComponent<AudioSource>().Play(0);
            int currentAmount = int.Parse(coinText.text) + value;
            coinText.text = currentAmount.ToString();
            animator.SetBool("IsCollect", true);
        }
    }
}
