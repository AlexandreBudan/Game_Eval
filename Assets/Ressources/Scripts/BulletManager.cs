using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public GameObject objectPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Launch1()
    {
        for (int i = -4; i < 5; i+=2)
        {
            GameObject newObject = Instantiate(objectPrefab, transform.position, objectPrefab.transform.rotation);

            Rigidbody2D rb = newObject.GetComponent<Rigidbody2D>();

            rb.velocity = new Vector3(-GameObject.FindWithTag("Player").GetComponent<CharacBehavior>().vitesse, i, 0);
        }
    }

    public void Launch2()
    {
        for (int i = -4; i < 5; i++)
        {
            GameObject newObject = Instantiate(objectPrefab, transform.position, objectPrefab.transform.rotation);

            newObject.transform.Translate(0, i, 0);

            Rigidbody2D rb = newObject.GetComponent<Rigidbody2D>();

            rb.velocity = new Vector3(-GameObject.FindWithTag("Player").GetComponent<CharacBehavior>().vitesse, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Vérifie si l'objet rencontré a le tag "ground" ou "boss"
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Bullet"))
        {
            // Détruire cet objet
            Destroy(gameObject);
        }
    }
}
