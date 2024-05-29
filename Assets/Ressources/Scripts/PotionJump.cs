using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PotionJump : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            GameObject.Find("PotionSound").GetComponent<AudioSource>().Play(0);
            col.GetComponent<CharacBehavior>().isGrounded = false;
            Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D>();
            Vector3 velo = rb.velocity;
            rb.velocity += new Vector2(0, -velo.y);
            rb.velocity += new Vector2(0, 20);
            Destroy(gameObject);
        }
    }
}
