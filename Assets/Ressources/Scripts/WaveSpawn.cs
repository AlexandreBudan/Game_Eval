using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawn : MonoBehaviour
{
    public GameObject[] easyWaves;
    public GameObject[] mediumWaves;
    public GameObject[] hardWaves;
    public GameObject[] bossWaves;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        SpawnWave();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnWave()
    {
        float characSpeed = player.GetComponent<CharacBehavior>().vitesse;
        int playerScore = PlayerPrefs.GetInt("Score") / 250;

        if (  playerScore >= 2 && playerScore % 3 == 0 && playerScore % 6 != 0 )
        {
            Instantiate(bossWaves[Random.Range(0, bossWaves.Length)], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
        } 
        else
        {
            if (characSpeed < 9)
            {
                Instantiate(easyWaves[Random.Range(0, easyWaves.Length)], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
            }
            else if (characSpeed >= 9 && characSpeed < 12)
            {
                Instantiate(mediumWaves[Random.Range(0, mediumWaves.Length)], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
            }
            else if (characSpeed >= 12)
            {
                Instantiate(hardWaves[Random.Range(0, hardWaves.Length)], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
            }
        }
    }
}
