using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSystem : MonoBehaviour
{
    public GameObject player;
    public Animator animator;
    private int state = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.transform.position.x + 18, 0, 0);
        }
    }

    public void GoFurther()
    {
        GameObject.Find("Music").GetComponent<AudioSource>().pitch = 1.30f;
        state = 0;
        animator.SetInteger("State", state);
    }

    public void GoCloser()
    {
        GameObject.Find("MonsterSound").GetComponent<AudioSource>().Play(0);
        GameObject.Find("Music").GetComponent<AudioSource>().pitch = 1.45f;
        state = 1;
        animator.SetInteger("State", state);
    }

    IEnumerator Atk1()
    {
        state = 2;
        animator.SetInteger("State", state);
        yield return new WaitForSeconds(0.5f);
        state = 1;
        animator.SetInteger("State", state);
    }

    IEnumerator Atk2()
    {
        state = 3;
        animator.SetInteger("State", state);
        yield return new WaitForSeconds(0.5f);
        state = 1;
        animator.SetInteger("State", state);
    }
}
