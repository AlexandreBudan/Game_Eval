using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSystem : MonoBehaviour
{
    public GameObject player;
    public Animator animator;
    public int state = 0;
    public GameObject bullet;
    private int atk = 0;

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
        if (state == 1)
        {
            if (atk == 0 && PlayerPrefs.GetInt("Score") % 250 == 50)
            {
                if (Random.Range(0, 2) == 0)
                {
                    StartCoroutine(Atk1());
                }
                else
                {
                    StartCoroutine(Atk2());
                }
                atk = 1;
            }
            else if (atk == 1 && PlayerPrefs.GetInt("Score") % 250 == 100)
            {
                if (Random.Range(0, 2) == 0)
                {
                    StartCoroutine(Atk1());
                }
                else
                {
                    StartCoroutine(Atk2());
                }
                atk = 2;
            }
            else if (atk == 2 && PlayerPrefs.GetInt("Score") % 250 == 150)
            {
                if (Random.Range(0, 2) == 0)
                {
                    StartCoroutine(Atk1());
                }
                else
                {
                    StartCoroutine(Atk2());
                }
                atk = 3;
            }
            else if (atk == 3 && PlayerPrefs.GetInt("Score") % 250 == 200)
            {
                if (Random.Range(0, 2) == 0)
                {
                    StartCoroutine(Atk1());
                }
                else
                {
                    StartCoroutine(Atk2());
                }
                atk = 4;
            }
            else if (atk == 4 && PlayerPrefs.GetInt("Score") % 250 == 0)
            {
                state = 0;
                animator.SetInteger("State", state);
            }
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
        yield return new WaitForSeconds(0.75f);
        state = 1;
        animator.SetInteger("State", state);
        bullet.GetComponent<BulletManager>().Launch1();
        yield return new WaitForSeconds(0.75f);
        bullet.GetComponent<BulletManager>().Launch1();
        yield return new WaitForSeconds(0.75f);
        bullet.GetComponent<BulletManager>().Launch1();

    }

    IEnumerator Atk2()
    {
        state = 3;
        animator.SetInteger("State", state);
        yield return new WaitForSeconds(0.75f);
        state = 1;
        animator.SetInteger("State", state);
        bullet.GetComponent<BulletManager>().Launch2();
        yield return new WaitForSeconds(0.75f);
        bullet.GetComponent<BulletManager>().Launch2();
        yield return new WaitForSeconds(0.75f);
        bullet.GetComponent<BulletManager>().Launch2();
    }
}
