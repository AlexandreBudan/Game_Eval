using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSystem : MonoBehaviour
{
    public AudioSource[] sounds;
    public AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        music.volume = PlayerPrefs.GetFloat("music", 1);
        foreach (AudioSource audio in sounds)
        {
            audio.volume = PlayerPrefs.GetFloat("sound", 1);
        }
    }
}
