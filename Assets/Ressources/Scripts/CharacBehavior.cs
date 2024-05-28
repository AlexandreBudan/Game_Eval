using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.InputSystem;

public class CharacBehavior : MonoBehaviour
{
    public InputActionAsset inputActions;
    private InputAction jumpAction;
    private InputAction shiftAction;
    private InputAction launchAction;

    public Rigidbody2D rb;
    public float vitesse;
    public float maxJump;
    public Animator animator;
    public bool isGrounded;
    private int isShifting = 0;
    private int isJumping = 0;
    public float VulnerabilityTime;
    public GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
        Time.timeScale = 1;
        setVelocity(vitesse, 0);
        StartCoroutine(AddSpeed());
    }

    // Update is called once per frame
    void Update()
    {
        int result = PlayerPrefs.GetInt("Score") / 250;
        if (result >= 2 && result % 3 == 0 && result % 6 != 0)
        {
            weapon.SetActive(true);
            GameObject.FindWithTag("Boss").GetComponent<BossSystem>().GoCloser();
        }
        else
        {
            weapon.SetActive(false);
            GameObject.FindWithTag("Boss").GetComponent<BossSystem>().GoFurther();
        }
    }

    private void OnEnable()
    {
        var playerControls = inputActions.FindActionMap("Player");

        jumpAction = playerControls.FindAction("Jump");
        shiftAction = playerControls.FindAction("Shift");
        launchAction = playerControls.FindAction("Launch");

        jumpAction.performed += ctx => Jump();
        shiftAction.performed += ctx => Shift();
        shiftAction.canceled += ctx => UnShift();
        launchAction.performed += ctx => weapon.GetComponent<WeaponManager>().Launch();

        jumpAction.Enable();
        shiftAction.Enable();
        launchAction.Enable();
    }

    private void OnDisable()
    {
        jumpAction.Disable();
        shiftAction.Disable();
        launchAction.Disable();
    }

    public void setVelocity(float xVelocity, float yVelocity)
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        rb.velocity += new Vector2(xVelocity, yVelocity);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            isJumping = 1;
            animator.SetInteger("IsJumping", isJumping);
            GameObject.Find("JumpSound").GetComponent<AudioSource>().Play(0);
            rb.velocity += new Vector2(0, maxJump);
            isGrounded = false;
        }
    }

    public void Shift()
    {
        if (isShifting == 0)
        {
            isShifting = 1;
            rb.velocity += new Vector2(0, -maxJump);
            animator.SetInteger("IsShifting", isShifting);
        }
    }

    public void UnShift()
    {
        isShifting = 0;
        animator.SetInteger("IsShifting", isShifting);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = 0;
            animator.SetInteger("IsJumping", isJumping);
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
            StartCoroutine(ObstacleFind());
        }
    }

    IEnumerator ObstacleFind()
    {
        yield return new WaitForSeconds(0.1f);
        GameObject.FindWithTag("Monster").GetComponent<MonsterSystem>().GoCloser();
        setVelocity(vitesse/2, 0);
        yield return new WaitForSeconds(0.5f);
        setVelocity(vitesse, 0);
        yield return new WaitForSeconds(VulnerabilityTime);
        GameObject.FindWithTag("Monster").GetComponent<MonsterSystem>().GoFurther();
    }

    IEnumerator AddSpeed()
    {
        while(vitesse < 14)
        {
            yield return new WaitForSeconds(1);
            vitesse += 0.01f;
            setVelocity(vitesse, 0);
        }
    }
}
