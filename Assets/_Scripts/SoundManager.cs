using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioClip[] sounds;
    public AudioSource musicSource,Winmusicsoure,losemusicsource;
    public GameObject[] soundIcons, MuteIcons;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;

        }
        musicSource.Play();
        if (PlayerPrefs.GetInt("sound")==0)
        {
            musicSource.enabled = false;
            Winmusicsoure.enabled = false;
            losemusicsource.enabled = false;
        }      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MuteSound()
    {
        musicSource.mute = true;
        for (int i = 0; i < 4; i++)
        {
            soundIcons[i].SetActive(false);
            MuteIcons[i].SetActive(true);
        }
    }

    public void PlaySound()
    {
        musicSource.mute = false;

        for(int i = 0; i < 4; i++)
        {
            MuteIcons[i].SetActive(false);
            soundIcons[i].SetActive(true);
        }
    }

    public void GameBgSound()
    {
        musicSource.clip = sounds[0];
        musicSource.Play();
    }


    public void Game1WheelSound()
    {
        musicSource.clip = sounds[1];
        musicSource.Play();
    }

    public void Game2CoinSound()
    {
        musicSource.clip = sounds[2];
        musicSource.Play();
    }

    public void Game3DicesSound()
    {
        musicSource.clip = sounds[3];
        musicSource.Play();
    }

    public void Game4LuckySpinnerSound()
    {
        musicSource.clip = sounds[4];
        musicSource.Play();
    }
}
