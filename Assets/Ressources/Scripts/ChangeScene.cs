using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string SceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSceneByName()
    {
        if (SceneName == "MainScene")
        {
            GameObject.Find("WindSound").GetComponent<AudioSource>().Stop();
        }
        SceneManager.LoadScene(SceneName);
    }
}
