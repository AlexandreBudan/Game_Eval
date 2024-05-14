using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacBehavior : MonoBehaviour
{
    public Rigidbody2D rb;
    public float vitesse;
    public float maxJump;
    private bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        setVelocity(vitesse, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    public void setVelocity(float xVelocity, float yVelocity)
    {
        rb.velocity = new Vector2(0, 0);
        rb.velocity += new Vector2(xVelocity, yVelocity);
    }

    public void Jump()
    {
        rb.velocity += new Vector2(0, maxJump);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            startCoroutine(ObstacleFind());
        }
    }

    IEnumerator ObstacleFind()
    {
        yield return new WaitForSeconds(0.1f);
        setVelocity(vitesse/2, 0);
        yield return new WaitForSeconds(0.5f);
        setVelocity(vitesse, 0);
    }
}
