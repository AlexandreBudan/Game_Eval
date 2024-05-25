using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigManager : MonoBehaviour
{
    public AudioSource[] sounds;
    public AudioSource music;
    public GameObject musicSlider;
    public GameObject soundSlider;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetFloat("music") != 0)
        {
            musicSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("music");
            music.volume = PlayerPrefs.GetFloat("music");
        }
        if (PlayerPrefs.GetFloat("sound") != 0)
        {
            soundSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("sound");
            foreach (AudioSource audio in sounds)
            {
                audio.volume = PlayerPrefs.GetFloat("sound");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setMusic()
    {
        float volume = musicSlider.GetComponent<Slider>().value;
        music.volume = volume;
        PlayerPrefs.SetFloat("music", volume);
    }

    public void setSound()
    {
        foreach (AudioSource audio in sounds)
        {
            float volume = soundSlider.GetComponent<Slider>().value;
            audio.volume = volume;
            PlayerPrefs.SetFloat("sound", volume);
        }
    }
}
