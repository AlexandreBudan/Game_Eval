using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSystem : MonoBehaviour
{
    public GameObject player;
    public Animator animator;
    public bool isKilling = false;
    private int state = 0;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.transform.position.x - 4.5f, -2.3f, -1);
            if (isKilling)
            {
                KillPlayer();
            }
        }
    }

    public void GoFurther()
    {
        GameObject.Find("Music").GetComponent<AudioSource>().pitch = 1.30f;
        state--;
        animator.SetInteger("State", state);
    }

    public void GoCloser()
    {
        GameObject.Find("MonsterSound").GetComponent<AudioSource>().Play(0);
        GameObject.Find("Music").GetComponent<AudioSource>().pitch = 1.45f;
        state++;
        animator.SetInteger("State", state);
    }

    public void KillPlayer()
    {
        canvas.GetComponent<CanvasManager>().GameOver();
        player = null;
    }
}
