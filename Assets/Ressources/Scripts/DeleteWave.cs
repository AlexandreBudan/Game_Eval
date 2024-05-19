using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteWave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WavePoint"))
        {
            Destroy(GameObject.FindWithTag("Wave"));
        }
    }
}
