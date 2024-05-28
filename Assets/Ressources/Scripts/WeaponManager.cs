using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject objectPrefab;
    public float launchSpeed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Launch()
    {
        int result = PlayerPrefs.GetInt("Score") / 250;
        if (result >= 2 && result % 3 == 0 && result % 6 != 0)
        {

            GameObject newObject = Instantiate(objectPrefab, transform.position, transform.rotation);

            Rigidbody2D rb = newObject.GetComponent<Rigidbody2D>();

            rb.velocity = new Vector3(launchSpeed, 0, 0);

            newObject.AddComponent<WeaponManager>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Vérifie si l'objet rencontré a le tag "ground" ou "boss"
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Boss"))
        {
            // Détruire cet objet
            Destroy(gameObject);
        }
    }
}
